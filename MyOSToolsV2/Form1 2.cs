using System;
using System.Collections.Generic;
using System.Management;
using System.Globalization;
using System.ComponentModel;
using System.Data;
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
    public partial class Form1 : Form
    {
        public Form1()
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
            string memory = GetHardwareInfo("TotalPhysicalMemory");

            // Récupération de l'ID TeamViewer
            string teamviewerid = GetTeamViewerID();

            // Récupération de la quantité de stockage de l'ordinateur
            //string storage = GetHardwareInfo("TotalPhysicalMemory");

            // Récupération des informations sur l'antivirus installé
            string antivirus = GetAntivirusInfo();

            // Récupération des informations réseaux
            string ipwifi = GetIPAndDHCPStatus("IPW");
            string ipethernet = GetIPAndDHCPStatus("IPE");
            string dhcpstatus = GetIPAndDHCPStatus("DHCP");

            // Récupération du stockage
            string storage = GetTotalDiskCapacity("TotalCapacity");
            string freespace = GetTotalDiskCapacity("TotalFreeSpace");

            // Récupération du dernier reboot
            string lastreboot = GetLastBootUpTime();

            // Affichage des informations récupérées dans les contrôles de la fenêtre
            txtSerialNumber.Text = serialNumber;
            txtManufacturer.Text = manufacturer;
            txtName.Text = domain + "\\" + pcname;
            txtModel.Text = model;
            txtOsVersion.Text = osVersion;
            txtProcessor.Text = processor;
            txtMemory.Text = memory;
            txtAntivirus.Text = antivirus;
            txtOS.Text = osInstalled;
            txtTeamViewer.Text = teamviewerid;
            txtIPW.Text = ipwifi;
            txtIPE.Text = ipethernet;
            txtDHCP.Text = dhcpstatus;
            txtStorage.Text = storage;
            txtLastReboot = lastreboot;

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
            string secondInfo = string.Empty; // Nouvelle variable pour stocker le nom du deuxième antivirus

            try
            {
                // Création de la requête WMI
                string query = "SELECT * FROM AntiVirusProduct";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\SecurityCenter2", query);

                // Exécution de la requête
                int count = 0; // Compteur pour compter le nombre d'antivirus détectés
                foreach (ManagementObject mo in searcher.Get())
                {
                    if (count == 0)
                    {
                        // Récupération du nom de l'antivirus
                        info = mo["displayName"].ToString();
                    }
                    else if (count == 1)
                    {
                        // Récupération du nom du deuxième antivirus
                        secondInfo = mo["displayName"].ToString();
                    }
                    else
                    {
                        // Plus de deux antivirus détectés, on arrête la boucle
                        break;
                    }

                    count++;
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Erreur lors de la récupération des informations sur l'antivirus : " + e.Message);
            }

            // Si un deuxième antivirus a été détecté, on renvoie son nom à la place du premier
            if (!string.IsNullOrEmpty(secondInfo))
            {
                info = secondInfo;
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
        public string GetTeamViewerID() //ne fonctionne pas de partout
        {
            // Ouvrez la clé de registre SOFTWARE.
            RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("SOFTWARE");
            if (softwareKey == null)
            {
                return "";
            }

            // Liste des emplacements où rechercher la valeur de registre ClientID
            string[] teamViewerKeys = {
        "TeamViewer",
        "WOW6432Node\\TeamViewer"
    };

            // Pour chaque emplacement, recherchez la valeur de registre ClientID
            foreach (string subKeyName in teamViewerKeys)
            {
                // Ouvrez la clé de registre TeamViewer.
                RegistryKey teamViewerKey = softwareKey.OpenSubKey(subKeyName);
                if (teamViewerKey == null)
                {
                    continue;
                }

                // Recherchez la valeur de registre ClientID dans la clé TeamViewer.
                object clientID = teamViewerKey.GetValue("ClientID");
                if (clientID == null)
                {
                    continue;
                }

                // Retournez la valeur de la valeur de registre ClientID.
                return clientID.ToString();
            }

            // Si aucune valeur de registre ClientID n'a été trouvée, retournez une chaîne vide.
            return "";
        }

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

        //Récuperer les informations de disque
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
        
        // Sauvegarde dans un fichier excel
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

        public string GetLastBootUpTime()
        {
            // Ouvrez la clé de registre SYSTEM.
            RegistryKey systemKey = Registry.LocalMachine.OpenSubKey("SYSTEM");
            if (systemKey == null)
            {
                return "";
            }

            // Recherchez la valeur de registre LastBootUpTime dans la clé SYSTEM.
            object lastBootUpTime = systemKey.GetValue("LastBootUpTime");
            if (lastBootUpTime == null)
            {
                return "";
            }

            // Convertissez la valeur de registre LastBootUpTime en DateTime.
            DateTime lastReboot = DateTime.FromFileTimeUtc((long)lastBootUpTime);
            string formattedDate = lastReboot.ToString("dd/MM/yyyy");

            // Convertissez la valeur de la DateTime en chaîne de caractères.
            return lastReboot.ToString();
        }

    }
}
