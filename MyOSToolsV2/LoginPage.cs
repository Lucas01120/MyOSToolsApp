using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Globalization;


namespace MyOSToolsV2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        public myostool MainForm { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                NetworkCredential credentials = new NetworkCredential(textBoxLogin.Text, textBoxPwd.Text);
                CookieContainer cookieContainer = new CookieContainer();

                string MyOSURL = "https://myos.one-system.fr/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MyOSURL);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                request.Headers.Add("Accept-Language", "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Referer = MyOSURL;
                request.Credentials = credentials;
                request.CookieContainer = cookieContainer;
                request.KeepAlive = false;

                string postData = "login=" + textBoxLogin.Text + "&pwd=" + textBoxPwd.Text;
                byte[] data = Encoding.ASCII.GetBytes(postData);
                request.ContentLength = data.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Création du corps de la requête
                
                string osInstalled = myostool.GetOperatingSystemName();
                string idteamviewer = myostool.GetTeamViewerID();
                string numserie = myostool.GetBiosInfo();
                string marque = myostool.GetHardwareInfo("Manufacturer");
                string model = myostool.GetHardwareInfo("Model");
                string computertype = myostool.GetComputerType();
                string idFamilleCatalogue = "";
                string nomFamille = "";
                if (computertype == "Laptop")
                {
                    idFamilleCatalogue = "33";
                    nomFamille = "ORDINATEUR PORTABLE";
                }
                else if (computertype == "Desktop")
                {
                    idFamilleCatalogue = "34";
                    nomFamille = "ORDINATEUR FIXE";

                }
                string userAssocie = Environment.UserName;
                string codePoste = myostool.GetHardwareInfo("Name");
                string nomAntivirus = myostool.GetAntivirusInfo();
                string iantivirus = "";
                if (nomAntivirus == "Sentinel Agent")
                {
                    iantivirus = "IANTIV-SENTI";
                }
                else if (nomAntivirus == "Kaspersky Endpoint Security for Windows")
                {
                    iantivirus = "IANTIV-KASPER";
                }
                else
                {
                    iantivirus = nomAntivirus;
                }
                string idTv = myostool.GetTeamViewerID();
                string processeur = myostool.GetProcInfo();
                string ram = myostool.GetTotalMemory();
                string disque = myostool.GetTotalDiskCapacity("TotalCapacity");
                string codeClient = GetSelectedClientId();

                // Récupération de la date d'installation
                string installDateStr = MainForm.GetinstallDate();
                DateTime installDate = DateTime.ParseExact(installDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // Calcul de la date de fin de garantie
                DateTime endOfWarrantyDate = MainForm.CalculateEndOfWarrantyDate(installDate);

                // Formatage de la date de fin de garantie
                string formattedEndOfWarrantyDate = endOfWarrantyDate.ToString("dd/MM/yyyy");

                // Utilisation de la date de fin de garantie
                string DateFinGarantie = formattedEndOfWarrantyDate;
                Console.WriteLine("garantie : " + DateFinGarantie);

            
                var body = new Dictionary<string, string>
    {
        { "codeClient", codeClient },
        { "numSerie", numserie },
        { "marque", marque },
        { "modele", model },
        { "idFamilleCatalogue", idFamilleCatalogue },
        { "nomFamille", nomFamille },
        { "systemExploitation", osInstalled },
        { "idUserAssocie", userAssocie },
        { "codePoste", codePoste },
        { "nomAntivirus", iantivirus },
        { "idTv", idTv },
        { "processeur", processeur },
        { "ram", ram },
        { "disque", disque }

    };

                string json = JsonConvert.SerializeObject(body);
                // Envoi de la data sur MyOS avec les identifiants

                HttpWebRequest syncRequest = (HttpWebRequest)WebRequest.Create(MyOSURL + "api.php");
                syncRequest.Method = "POST";
                syncRequest.ContentType = "application/json; charset=UTF-8";
                syncRequest.CookieContainer = cookieContainer;

                using (var streamWriter = new StreamWriter(syncRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse syncResponse = (HttpWebResponse)syncRequest.GetResponse();
                using (var streamReader = new StreamReader(syncResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (result.Contains("Utilisateur non authentifié"))
                    {
                        MessageBox.Show("Erreur : Mot de passe ou utilisateur incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Console.WriteLine(result);
                    //Console.WriteLine(syncResponse);
                    //Console.WriteLine(body);
                    MessageBox.Show("Les données ont bien été synchronisées. Penser à compléter ces informations sur MyOS", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("ERREUR DE CONNEXION", "Une erreur s'est produite lors de la connexion web : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Console.WriteLine("Informations sur la connexion : " + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR DE CONNEXION :", "Une erreur inattendue s'est produite : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Console.WriteLine("Informations sur l'erreur : " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string selectedClientId;
        public string GetSelectedClientId()
        {
            return selectedClientId;
        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = comboBox1.SelectedItem.ToString();
            string[] splitText = selectedText.Split(new[] { " - " }, StringSplitOptions.None);
            string selectedId = splitText[1];

            selectedClientId = selectedId;
            
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

            if (comboBox1.Items.Count == 0)
            {
                NetworkCredential credentials = new NetworkCredential(textBoxLogin.Text, textBoxPwd.Text);
                CookieContainer cookieContainer = new CookieContainer();

                string MyOSURL = "https://myos.one-system.fr/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MyOSURL);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                request.Headers.Add("Accept-Language", "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Referer = MyOSURL;
                request.Credentials = credentials;
                request.CookieContainer = cookieContainer;
                request.KeepAlive = false;

                string postData = "login=" + textBoxLogin.Text + "&pwd=" + textBoxPwd.Text;
                byte[] data = Encoding.ASCII.GetBytes(postData);
                request.ContentLength = data.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();

                string url = "https://myos.one-system.fr/rqt/requetes.php?cFct=lstClt&idBdd=0&_type=query";
                string postData2 = "";

                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url);
                request2.Method = "POST";
                request2.ContentType = "application/x-www-form-urlencoded";
                request2.CookieContainer = cookieContainer;

                byte[] data2 = Encoding.ASCII.GetBytes(postData2);
                request2.ContentLength = data2.Length;

                using (Stream stream = request2.GetRequestStream())
                {
                    stream.Write(data2, 0, data2.Length);
                }

                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                using (Stream stream = response2.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string responseString = reader.ReadToEnd();
                    Console.WriteLine(responseString);
                    

                    // Deserialize JSON
                    //var jsonData = JsonConvert.DeserializeObject<dynamic>(responseString);
                    try
                    {
                        JObject jsonObject = JObject.Parse(responseString);
                        JArray results = (JArray)jsonObject["results"];

                        foreach (JObject result in results)
                        {
                            string id = (string)result.GetValue("id").ToString();
                            string nomClientSansCode = (string)result.GetValue("nomClientSansCode");

                            comboBox1.Items.Add(nomClientSansCode + " - " + id);
                        }
                    }
                    catch (JsonReaderException ex)
                    {
                        // Afficher un message d'erreur à l'utilisateur
                        MessageBox.Show("Utilisateur ou mot de passe incorrect", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    finally
                    {
                        response2.Close(); // fermer la connexion
                    }
                }
            }   

        }
    }
}
