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

        }

        // Fonction pour récupérer les informations sur l'ordinateur
        static string GetHardwareInfo(string hardwareInfo)
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

        // Fonction pour récupérer les informations sur l'antivirus installé
        static string GetAntivirusInfo()
        {
            string info = string.Empty;

            try
            {
                // Création de la requête WMI
                string query = "SELECT * FROM AntiVirusProduct";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\SecurityCenter2", query);

                // Exécution de la requête
                foreach (ManagementObject mo in searcher.Get())
                {
                    // Récupération du nom de l'antivirus
                    info = mo["displayName"].ToString();
                    break;
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération des informations sur l'antivirus : " + e.Message);
            }

            return info;
        }

        //Fonction pour récupérer le numéro de série
        static string GetBiosInfo()
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
                Console.WriteLine("Erreur lors de la récupération des informations sur l'antivirus : " + e.Message);
            }

            return info;
        }


        //Fonction pour récupérer le Processeur
        static string GetProcInfo()
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
                        break; // On arrête de chercher dès qu'on a trouvé la clé
                    }
                }
                catch (Exception ex)
                {
                    return ("TeamViewer non détecter");
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
        public string GetTotalDiskCapacity(string StorageCapacity)
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
        public string GetTotalMemory()
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
            // Création d'une nouvelle application Excel
            ExcelApplication excelApp = new ExcelApplication();

            // Ajout d'un nouveau classeur
            Workbook workbook = excelApp.Workbooks.Add();

            // Sélection de la première feuille du classeur
            Worksheet worksheet = workbook.Worksheets[1];

            // Récupération des valeurs des textbox
            FormsTextBox[] textboxes = { txtSerialNumber, txtManufacturer, txtName, txtModel, txtOsVersion,
            txtProcessor, txtMemory, txtAntivirus, txtOS, txtTeamViewer, txtIPW, txtIPE, txtDHCP };

            // Ajout des valeurs des textbox dans la première ligne de la feuille
            for (int i = 0; i < textboxes.Length; i++)
            {
                worksheet.Cells[1, i + 1] = textboxes[i].Text;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            // Téléchargement de l'application
            using (WebClient client = new WebClient())
            {
                try
                {
                    // Téléchargement du fichier à l'emplacement temporaire
                    string tempFile = Path.GetTempFileName();
                    await client.DownloadFileTaskAsync("https://www.one-system.fr/TeamViewer.exe", tempFile);

                    // Installation de l'application en mode silencieux
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = tempFile;
                    startInfo.Arguments = "/S"; // Arguments pour l'installation silencieuse
                    Process.Start(startInfo);
                }
                catch (WebException ex)
                {
                    // Gestion des erreurs de téléchargement
                }
            }
        }
    }
}
