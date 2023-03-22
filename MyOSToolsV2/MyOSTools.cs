using System;
using System.Collections.Generic;
using System.Management;
using System.Globalization;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.IO;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using Microsoft.Office.Interop.Excel;
using FormsApplication = System.Windows.Forms.Application;
using FormsTextBox = System.Windows.Forms.TextBox;





namespace MyOSToolsV2
{
    public partial class myostool : Form
    {
        public myostool()
        {
            InitializeComponent();
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            // Récupération du numéro de série de l'ordinateur
            string serialNumber = GetBiosInfo();

            // Récupération de la marque de l'ordinateur
            string manufacturer = GetHardwareInfo("Manufacturer");

            // Récupération du modèle de l'ordinateur
            string model = GetHardwareInfo("Model");

            // Récupération du nom de l'ordinateur
            string pcname = GetHardwareInfo("Name");

            // Récupération du Domain
            string domain = GetHardwareInfo("Domain");

            // Récupération de la version du système d'exploitation
            string osVersion = GetOperatingSystemInfo("BuildNumber");

            // Récuperation du nom du système d'exploitation
            string osInstalled = GetOperatingSystemInfo("Caption");

            // Récupération de la date d'installation du système
            string InstallDate = GetOperatingSystemInfo("installDate");

            // Récupération des informations sur le processeur
            string processor = GetProcInfo();

            // Récupération de la quantité de RAM installée
            //string memory = GetHardwareInfo("TotalPhysicalMemory");

            // Récupération de l'ID TeamViewer
            string teamviewerid = GetTeamViewerID();

            // Récupération de la quantité de RAM
            string virtualmemory = GetTotalMemory();

            // Récupération des informations sur l'antivirus installé
            string antivirus = GetAntivirusInfo();

            // Récupération du type d'ordinateur
            string computertype = GetComputerType();
            

            // Récupération des informations réseaux
            string ipwifi = GetIPAndDHCPStatus("IPW");
            string ipethernet = GetIPAndDHCPStatus("IPE");
            string dhcpstatus = GetIPAndDHCPStatus("DHCP");

            // Récupération du stockage
            string storage = GetTotalDiskCapacity("TotalCapacity");
            string freeSpacePercentage = GetTotalDiskCapacity("TotalFreeSpace");

            //double uptime = GetUptime();
            string uptimeString = GetUptimeString();

            // Affichage des informations récupérées dans les contrôles de la fenêtre
            txtSerialNumber.Text = serialNumber;
            txtManufacturer.Text = manufacturer;
            txtName.Text = domain + "\\" + pcname;
            txtModel.Text = model;
            txtOsVersion.Text = osVersion;
            txtProcessor.Text = processor;
            //txtMemory.Text = memory;
            txtAntivirus.Text = antivirus;
            txtOS.Text = osInstalled;
            txtTeamViewer.Text = teamviewerid;
            txtIPW.Text = ipwifi;
            txtIPE.Text = ipethernet;
            txtDHCP.Text = dhcpstatus;
            txtStorage.Text = storage;
            txtStoragePrct.Text = freeSpacePercentage;
            txtMemory.Text = virtualmemory;
            txtLastReboot.Text = uptimeString;

            synchro.Enabled = true;
            enregistrement.Enabled = true;
        }

        // Fonction pour récupérer les informations sur l'ordinateur
        public static string GetHardwareInfo(string hardwareInfo)
        {
            string info = string.Empty;

            try
            {
                // Création de la requête WMI
                string query = "SELECT " + hardwareInfo + " FROM Win32_ComputerSystem";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                // Exécution de la requête
                foreach (ManagementObject mo in searcher.Get())
                {
                    Console.WriteLine(mo[hardwareInfo]);
                    // Récupération de l'information souhaitée
                    string hardwareValue = mo[hardwareInfo].ToString();

                    // Si l'information recherchée est la capacité totale du disque dur, on la convertit en Go
                    if (hardwareInfo == "TotalPhysicalMemory")
                    {
                        
                    }
                    else
                    {
                        // Si l'information recherchée n'est pas la capacité totale du disque dur, on retourne la valeur telle quelle
                        info = hardwareValue;
                    }
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération des informations sur l'ordinateur : " + e.Message);
            }

            return info;
        }

        // Fonction pour recupere uniquement le nom du systeme :
        public static string GetOperatingSystemName()
        {
            string operatingSystem = string.Empty;

            try
            {
                // Récupération des informations système
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject mo in searcher.Get())
                {
                    operatingSystem = mo["Caption"].ToString();
                    break;
                }

                if (operatingSystem.Contains("Microsoft Windows 11 Professionnel"))
                {
                    operatingSystem = "Windows 11 Pro";
                }
                else if (operatingSystem.Contains("Microsoft Windows 10 Professionnel"))
                {
                    operatingSystem = "Windows 10 Pro";
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération des informations sur le système d'exploitation : " + e.Message);
            }

            return operatingSystem;
        }

        // Fonction pour récupérer les informations sur le système d'exploitation
        public string GetOperatingSystemInfo(string osInfo)
        {
            string info = string.Empty;

            try
            {
                // Création de la requête WMI
                string query = "SELECT " + osInfo + " FROM Win32_OperatingSystem";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                // Exécution de la requête
                foreach (ManagementObject mo in searcher.Get())
                {
                    // Si l'information recherchée est la date d'installation du système d'exploitation
                    if (osInfo == "installDate")
                    {
                        // Récupération de la date d'installation
                        string installDate = mo[osInfo].ToString();

                        // Suppression de tout ce qui se trouve après le "." dans la chaîne de caractères
                        int indexOfDot = installDate.IndexOf(".");
                        if (indexOfDot > 0)
                        {
                            installDate = installDate.Substring(0, indexOfDot);
                            installDate = installDate.Substring(0, 8);
                            Console.WriteLine(installDate);
                        }

                        // Formatage de la date d'installation
                        DateTime date = DateTime.ParseExact(installDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                        string formattedDate = date.ToString("dd/MM/yyyy");

                        // Affichage de la date d'installation dans le TextBox
                        txtInstallDate.Text = formattedDate;
                    }
                    else
                    {
                        // Si l'information recherchée n'est pas la date d'installation, on affiche l'information telle quelle
                        info = mo[osInfo].ToString();
                    }
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération des informations sur le système d'exploitation : " + e.Message);
            }

            return info;
        }

        // fonction public pour la date d'installation du SE
        public string GetinstallDate()
        {
            return GetOperatingSystemInfo("InstallDate");
        }

        // ajout des 36 mois pour la date fin garantie.
        public DateTime CalculateEndOfWarrantyDate(DateTime installDate)
        {
            return installDate.AddMonths(36);
        }

        // Fonction pour récupérer les informations sur l'antivirus installé
        public static string GetAntivirusInfo()
        {
            string info = string.Empty;

            try
            {
                // Création de la requête WMI
                string query = "SELECT * FROM AntiVirusProduct";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\SecurityCenter2", query);

                // Exécution de la requête
                ManagementObjectCollection antivirusProducts = searcher.Get();

                // Stocker les noms des antivirus dans un tableau
                string[] antivirusNames = new string[antivirusProducts.Count];
                int count = 0;
                foreach (ManagementObject mo in antivirusProducts)
                {
                    antivirusNames[count] = mo["displayName"].ToString();
                    count++;
                }

                // Si il y a 2 valeurs dans le tableau, afficher la 2ème valeur
                // Sinon, afficher la première valeur
                if (antivirusNames.Length > 1)
                {
                    info = antivirusNames[1];
                }
                else
                {
                    info = antivirusNames[0];
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération des informations sur l'antivirus : " + e.Message);
            }

            return info;
        }

        //Fonction pour recuperer le typ d'ordinateur
        public static string GetComputerType()
        {
            string computerType = "Laptop";

            try
            {
                // Création de la requête WMI
                string query = "SELECT * FROM Win32_DesktopMonitor";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                // Exécution de la requête
                int count = 0;
                foreach (ManagementObject mo in searcher.Get())
                {
                    count++;
                }

                if (count > 1)
                {
                    computerType = "Desktop";
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération du type d'ordinateur : " + e.Message);
            }

            return computerType;
        }

        //Fonction pour récupérer le numéro de série
        public static string GetBiosInfo()
        {
            string info = string.Empty;

            try
            {
                // Création de la requête WMI
                string query = "SELECT * FROM Win32_Bios";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);


                // Exécution de la requête
                foreach (ManagementObject mo in searcher.Get())
                {
                    info = mo["SerialNumber"].ToString();
                    break;
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération du bios : " + e.Message);
            }

            return info;
        }


        //Fonction pour récupérer le Processeur
        public static string GetProcInfo()
        {
            string info = string.Empty;

            try
            {
                // Création de la requête WMI
                string query = "SELECT * FROM Win32_processor";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);


                // Exécution de la requête
                foreach (ManagementObject mo in searcher.Get())
                {
                    info = mo["Name"].ToString();
                    break;
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération des informations sur l'antivirus : " + e.Message);
            }

            return info;
        }

        //Fonction pour récupérer l'ID TeamViewer
        public static string GetTeamViewerID()
        {
            string teamViewerID = "";

            // Check if the ID exists in the rolloutfile.tv13 file
            string[] filePaths = {
        @"C:\Program Files (x86)\TeamViewer\rolloutfile.tv13",
        @"C:\Program Files\TeamViewer\rolloutfile.tv13"
    };

            foreach (string filePath in filePaths)
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        string fileContent = File.ReadAllText(filePath);
                        int firstCommaIndex = fileContent.IndexOf(',');
                        if (firstCommaIndex >= 0)
                        {
                            teamViewerID = fileContent.Substring(0, firstCommaIndex);
                            break; // Stop looking for the ID as soon as it is found
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error de récuperation: " + ex.Message);
                        return ("TeamViewer non identifié");

                    }
                }
            }

            // If the ID was not found in the file, look for it in the registry
            if (string.IsNullOrEmpty(teamViewerID))
            {
                string[] keyPaths = {
            @"SOFTWARE\WOW6432Node\TeamViewer",
            @"SOFTWARE\TeamViewer",
            @"SOFTWARE\TeamViewer\Version7"
        };

                foreach (string keyPath in keyPaths)
                {
                    try
                    {
                        RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
                        if (key != null)
                        {
                            teamViewerID = key.GetValue("ClientID").ToString();
                            key.Close();
                            break; // Stop looking for the ID as soon as it is found
                        }
                    }
                    catch (Exception ex)
                    {
                        return ("TeamViewer not detected: " + ex.Message);
                    }
                }
            }

            return teamViewerID;
        }


        //Fonction de récuperation IP et DHCP
        public string GetIPAndDHCPStatus(string type)
        {
            if (type == "IPW")
            {
                // Récupération de l'adresse IP WiFi
                string ipAddress = string.Empty;
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && ni.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipAddress = ip.Address.ToString();
                                break;
                            }
                        }
                    }
                }
                return ipAddress;
            }
            else if (type == "IPE")
            {
                // Récupération de l'adresse IP Ethernet
                string ipAddress = string.Empty;
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet && ni.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipAddress = ip.Address.ToString();
                                break;
                            }
                        }
                    }
                }
                return ipAddress;
            }
            else if (type == "DHCP")
            {
                // Récupération de l'état du DHCP
                string dhcpStatus = NetworkInterface.GetAllNetworkInterfaces()[0].GetIPProperties().GetIPv4Properties().IsDhcpEnabled ? "Activé" : "Désactivé";
                return dhcpStatus;
            }
            else
            {
                return string.Empty;
            }
        }

        //Fonction de récuperation de l'espace disque
        public static string GetTotalDiskCapacity(string StorageCapacity)
        {
            if (StorageCapacity == "TotalCapacity")
            {
                // Récupération de la capacité totale du disque dur en octets
                long totalCapacity = new DriveInfo("C").TotalSize;

                // Conversion de la capacité totale en Go
                double totalCapacityInGo = totalCapacity / 1073741824.0;

                // Arrondi de la capacité totale en Go a l'unité inférieure
                totalCapacityInGo = Math.Floor(totalCapacityInGo);

                // Retour de la capacité totale en Go sous forme de chaîne de caractères
                return totalCapacityInGo.ToString() + " Go";
            }
            else if (StorageCapacity == "TotalFreeSpace")
            {
                // Récupération de la capacité totale du disque dur en octets
                long totalCapacity = new DriveInfo("C").TotalSize;

                // Récupération de l'espace libre restant en octets
                long freeSpace = new DriveInfo("C").TotalFreeSpace;

                // Calcul du pourcentage d'espace libre restant
                double freeSpacePercentage = (double)freeSpace / (double)totalCapacity * 100.0;

                // Arrondi le pourcentage d'espace libre restant a l'unité inférieure
                freeSpacePercentage = Math.Floor(freeSpacePercentage);
                return freeSpacePercentage.ToString();
            }
            else
            {
                return string.Empty;

            }
        }

        //Fonction de récuperation de la mémoir vive
        public static string GetTotalMemory()
        {
            // Définir une requête WMI pour obtenir des informations sur la mémoire vive
            string query = "SELECT Capacity FROM Win32_PhysicalMemory";

            // Exécuter la requête WMI
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection results = searcher.Get();

            // Calculer la quantité totale de mémoire vive en bytes
            long memoryInBytes = 0;
            foreach (ManagementObject result in results)
            {
                memoryInBytes += Convert.ToInt64(result["Capacity"]);
            }

            // Convertir la quantité de mémoire en Go
            double memoryInGB = memoryInBytes / 1024.0 / 1024.0 / 1024.0;

            // Retourner la quantité de mémoire en Go sous forme de chaîne de caractères
            return memoryInGB.ToString();
        }

        //Fonction utilisateur


        //Fonction de récuperation du derniere reboot
        static string GetUptimeString()
        {
            string uptimeString = "inconnu"; // Valeur par défaut en cas d'échec de la requête WMI

            try
            {
                // Création de la requête WMI
                string query = "SELECT LastBootUpTime FROM Win32_OperatingSystem";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                // Exécution de la requête
                foreach (ManagementObject mo in searcher.Get())
                {
                    // Récupération de la date et heure du dernier redémarrage
                    DateTime lastBootUpTime = ManagementDateTimeConverter.ToDateTime(mo["LastBootUpTime"].ToString());

                    // Calcul du nombre de jours écoulés depuis le dernier redémarrage
                    TimeSpan elapsedTime = DateTime.Now - lastBootUpTime;
                    double uptime = elapsedTime.TotalDays;

                    if (uptime < 1)
                    {
                        uptimeString = "moins d'une journée";
                    }
                    else
                    {
                        uptimeString = uptime.ToString("F2") + " jours";
                    }
                    break;
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération du temps de fonctionnement : " + e.Message);
            }

            return uptimeString;
        }

        //Boutton d'enregistrement
        private void enregistrement_Click(object sender, EventArgs e)
        {
            string computertype = myostool.GetComputerType();
            string nomFamille = "";
            if (computertype == "Laptop")
            {
                nomFamille = "ORDINATEUR PORTABLE";
            }
            else if (computertype == "Desktop")
            {
                nomFamille = "ORDINATEUR FIXE";

            }
            // Création d'une nouvelle application Excel
            ExcelApplication excelApp = new ExcelApplication();

            // Ajout d'un nouveau classeur
            Workbook workbook = excelApp.Workbooks.Add();

            // Sélection de la première feuille du classeur
            Worksheet worksheet = workbook.Worksheets[1];

            // tableau du modele
            worksheet.Cells[1, 1] = "CODE-CLIENT";
            worksheet.Cells[1, 2] = "NOM-CLIENT";
            worksheet.Cells[1, 3] = "NUM-SERIE";
            worksheet.Cells[1, 4] = "MARQUE";
            worksheet.Cells[1, 5] = "MODELE";
            worksheet.Cells[1, 6] = "FAMILLE-PRODUIT";
            worksheet.Cells[1, 7] = "ETAT-DE-GARANTIE_MAINTENANCE-LOGICIELLE";
            worksheet.Cells[1, 8] = "COUVERTURE-INFOGERANCE";
            worksheet.Cells[1, 9] = "COUVERTURE-ANTIVIRALE";
            worksheet.Cells[1, 10] = "SYSTEME-EXPLOITATION";
            worksheet.Cells[1, 11] = "ETAT-DE-PRESENCE";
            worksheet.Cells[1, 12] = "LOCATION";
            worksheet.Cells[1, 13] = "UTILISATEUR-ASSOCIE";
            worksheet.Cells[1, 14] = "SITUATION-GEOGRAPHIQUE";
            worksheet.Cells[1, 15] = "ID-TV";
            worksheet.Cells[1, 16] = "COMMENTAIRE";
            worksheet.Cells[1, 17] = "DATE-FACTURE";
            worksheet.Cells[1, 18] = "DUREE-GARANTIE";
            worksheet.Cells[1, 19] = "DATE-FIN-GTIE";
            worksheet.Cells[1, 20] = "PROC";
            worksheet.Cells[1, 21] = "RAM";
            worksheet.Cells[1, 22] = "DISQUE";
            worksheet.Cells[1, 23] = "IP";
            worksheet.Cells[1, 24] = "NOM-NETBIOS";

            // Variables pour stocker les valeurs des textboxes
            string serialNumber = txtSerialNumber.Text;
            string manufacturer = txtManufacturer.Text;
            string model = txtModel.Text;
            string os = txtOS.Text;
            string antivirus = txtAntivirus.Text;
            string teamViewer = txtTeamViewer.Text;
            string processor = txtProcessor.Text;
            string memory = txtMemory.Text;
            string storage = txtStorage.Text;
            string userAssocie = Environment.UserName;

            // Liste pour stocker les valeurs dans l'ordre spécifié
            List<string> values = new List<string> { "CLXXXXX", "MON CLIENT", serialNumber, manufacturer, model, nomFamille, null, null, antivirus, os, "1", null, userAssocie, null, teamViewer, null, null, null, null, processor, memory, storage };

            // Ajout des valeurs des textbox dans la 2ième ligne de la feuille
            for (int i = 0; i < values.Count; i++)
            {
                worksheet.Cells[2, i + 1] = values[i];
            }

            // Demande à l'utilisateur où enregistrer le fichier Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Enregistrement du fichier Excel
                workbook.SaveAs(saveFileDialog.FileName);
            }

            // Fermeture de l'application Excel
            excelApp.Quit();
        }

        private void CheckTextBox()
        {
            // Vérification du texte de la TextBox
            if (txtTeamViewer.Text == "TeamViewer non détecté")
            {
                // Affichage du bouton
                button1.Visible = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Téléchargement de l'application
            Process.Start("https://www.one-system.fr/TeamViewer.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var LoginForm = new LoginForm();
            LoginForm.MainForm = this;
            LoginForm.ShowDialog();
        }

        public void txtInstallDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
