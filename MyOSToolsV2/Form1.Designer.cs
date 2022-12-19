
namespace MyOSToolsV2
{
    partial class myostool
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myostool));
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtOsVersion = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtMemory = new System.Windows.Forms.TextBox();
            this.txtProcessor = new System.Windows.Forms.TextBox();
            this.txtAntivirus = new System.Windows.Forms.TextBox();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Tab1 = new System.Windows.Forms.Label();
            this.pcname = new System.Windows.Forms.Label();
            this.SystemOS = new System.Windows.Forms.Label();
            this.OSVersion = new System.Windows.Forms.Label();
            this.Tab2 = new System.Windows.Forms.Label();
            this.Manufacturer = new System.Windows.Forms.Label();
            this.model = new System.Windows.Forms.Label();
            this.SerialNumber = new System.Windows.Forms.Label();
            this.Proc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.antivirus = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.txtInstallDate = new System.Windows.Forms.TextBox();
            this.Tab3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTeamViewer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIPE = new System.Windows.Forms.TextBox();
            this.txtIPW = new System.Windows.Forms.TextBox();
            this.txtDHCP = new System.Windows.Forms.TextBox();
            this.txtLastReboot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStoragePrct = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.enregistrement = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(50, 812);
            this.btnGetInfo.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(194, 44);
            this.btnGetInfo.TabIndex = 0;
            this.btnGetInfo.Text = "Lancer le scan";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerialNumber.Location = new System.Drawing.Point(302, 598);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(6);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(234, 34);
            this.txtSerialNumber.TabIndex = 1;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManufacturer.Location = new System.Drawing.Point(302, 498);
            this.txtManufacturer.Margin = new System.Windows.Forms.Padding(6);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.ReadOnly = true;
            this.txtManufacturer.Size = new System.Drawing.Size(196, 34);
            this.txtManufacturer.TabIndex = 2;
            // 
            // txtOsVersion
            // 
            this.txtOsVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOsVersion.Location = new System.Drawing.Point(302, 246);
            this.txtOsVersion.Margin = new System.Windows.Forms.Padding(6);
            this.txtOsVersion.Name = "txtOsVersion";
            this.txtOsVersion.ReadOnly = true;
            this.txtOsVersion.Size = new System.Drawing.Size(196, 34);
            this.txtOsVersion.TabIndex = 4;
            // 
            // txtModel
            // 
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.Location = new System.Drawing.Point(302, 548);
            this.txtModel.Margin = new System.Windows.Forms.Padding(6);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(234, 34);
            this.txtModel.TabIndex = 3;
            // 
            // txtMemory
            // 
            this.txtMemory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemory.Location = new System.Drawing.Point(302, 716);
            this.txtMemory.Margin = new System.Windows.Forms.Padding(6);
            this.txtMemory.Name = "txtMemory";
            this.txtMemory.ReadOnly = true;
            this.txtMemory.Size = new System.Drawing.Size(196, 34);
            this.txtMemory.TabIndex = 6;
            // 
            // txtProcessor
            // 
            this.txtProcessor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcessor.Location = new System.Drawing.Point(302, 654);
            this.txtProcessor.Margin = new System.Windows.Forms.Padding(6);
            this.txtProcessor.Name = "txtProcessor";
            this.txtProcessor.ReadOnly = true;
            this.txtProcessor.Size = new System.Drawing.Size(422, 34);
            this.txtProcessor.TabIndex = 5;
            // 
            // txtAntivirus
            // 
            this.txtAntivirus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAntivirus.Location = new System.Drawing.Point(302, 306);
            this.txtAntivirus.Margin = new System.Windows.Forms.Padding(6);
            this.txtAntivirus.Name = "txtAntivirus";
            this.txtAntivirus.ReadOnly = true;
            this.txtAntivirus.Size = new System.Drawing.Size(196, 34);
            this.txtAntivirus.TabIndex = 8;
            // 
            // txtStorage
            // 
            this.txtStorage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStorage.Location = new System.Drawing.Point(1186, 368);
            this.txtStorage.Margin = new System.Windows.Forms.Padding(6);
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.ReadOnly = true;
            this.txtStorage.Size = new System.Drawing.Size(196, 34);
            this.txtStorage.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(302, 112);
            this.txtName.Margin = new System.Windows.Forms.Padding(6);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(396, 34);
            this.txtName.TabIndex = 9;
            // 
            // Tab1
            // 
            this.Tab1.AutoSize = true;
            this.Tab1.Font = new System.Drawing.Font("Microsoft Tai Le", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab1.Location = new System.Drawing.Point(58, 46);
            this.Tab1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Tab1.Name = "Tab1";
            this.Tab1.Size = new System.Drawing.Size(116, 27);
            this.Tab1.TabIndex = 10;
            this.Tab1.Text = "IDENTITE :";
            // 
            // pcname
            // 
            this.pcname.AutoSize = true;
            this.pcname.Location = new System.Drawing.Point(58, 120);
            this.pcname.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pcname.Name = "pcname";
            this.pcname.Size = new System.Drawing.Size(210, 26);
            this.pcname.TabIndex = 11;
            this.pcname.Text = "Nom de l\'ordinateur :";
            // 
            // SystemOS
            // 
            this.SystemOS.AutoSize = true;
            this.SystemOS.Location = new System.Drawing.Point(58, 192);
            this.SystemOS.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SystemOS.Name = "SystemOS";
            this.SystemOS.Size = new System.Drawing.Size(232, 26);
            this.SystemOS.TabIndex = 12;
            this.SystemOS.Text = "Système d\'exploitation :";
            // 
            // OSVersion
            // 
            this.OSVersion.AutoSize = true;
            this.OSVersion.Location = new System.Drawing.Point(58, 252);
            this.OSVersion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.OSVersion.Name = "OSVersion";
            this.OSVersion.Size = new System.Drawing.Size(131, 26);
            this.OSVersion.TabIndex = 13;
            this.OSVersion.Text = "Version OS : ";
            // 
            // Tab2
            // 
            this.Tab2.AutoSize = true;
            this.Tab2.Font = new System.Drawing.Font("Microsoft Tai Le", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab2.Location = new System.Drawing.Point(50, 432);
            this.Tab2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Tab2.Name = "Tab2";
            this.Tab2.Size = new System.Drawing.Size(125, 27);
            this.Tab2.TabIndex = 14;
            this.Tab2.Text = "MATERIEL :";
            // 
            // Manufacturer
            // 
            this.Manufacturer.AutoSize = true;
            this.Manufacturer.Location = new System.Drawing.Point(50, 504);
            this.Manufacturer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.Size = new System.Drawing.Size(95, 26);
            this.Manufacturer.TabIndex = 15;
            this.Manufacturer.Text = "Marque :";
            // 
            // model
            // 
            this.model.AutoSize = true;
            this.model.Location = new System.Drawing.Point(50, 554);
            this.model.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(93, 26);
            this.model.TabIndex = 16;
            this.model.Text = "Modèle :";
            // 
            // SerialNumber
            // 
            this.SerialNumber.AutoSize = true;
            this.SerialNumber.Location = new System.Drawing.Point(50, 604);
            this.SerialNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.Size = new System.Drawing.Size(177, 26);
            this.SerialNumber.TabIndex = 17;
            this.SerialNumber.Text = "Numéro de serie :";
            // 
            // Proc
            // 
            this.Proc.AutoSize = true;
            this.Proc.Location = new System.Drawing.Point(50, 660);
            this.Proc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Proc.Name = "Proc";
            this.Proc.Size = new System.Drawing.Size(205, 26);
            this.Proc.TabIndex = 18;
            this.Proc.Text = "Nom du processeur :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 724);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 26);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mémoir RAM (Go) :";
            // 
            // antivirus
            // 
            this.antivirus.AutoSize = true;
            this.antivirus.Location = new System.Drawing.Point(58, 312);
            this.antivirus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.antivirus.Name = "antivirus";
            this.antivirus.Size = new System.Drawing.Size(188, 26);
            this.antivirus.TabIndex = 20;
            this.antivirus.Text = "Antivirus installer : ";
            // 
            // txtOS
            // 
            this.txtOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOS.Location = new System.Drawing.Point(302, 188);
            this.txtOS.Margin = new System.Windows.Forms.Padding(6);
            this.txtOS.Name = "txtOS";
            this.txtOS.ReadOnly = true;
            this.txtOS.Size = new System.Drawing.Size(396, 34);
            this.txtOS.TabIndex = 21;
            // 
            // txtInstallDate
            // 
            this.txtInstallDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstallDate.Location = new System.Drawing.Point(1186, 320);
            this.txtInstallDate.Margin = new System.Windows.Forms.Padding(6);
            this.txtInstallDate.Name = "txtInstallDate";
            this.txtInstallDate.ReadOnly = true;
            this.txtInstallDate.Size = new System.Drawing.Size(196, 34);
            this.txtInstallDate.TabIndex = 22;
            // 
            // Tab3
            // 
            this.Tab3.AutoSize = true;
            this.Tab3.Font = new System.Drawing.Font("Microsoft Tai Le", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab3.Location = new System.Drawing.Point(888, 46);
            this.Tab3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Tab3.Name = "Tab3";
            this.Tab3.Size = new System.Drawing.Size(88, 27);
            this.Tab3.TabIndex = 23;
            this.Tab3.Text = "DIAGS :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(888, 324);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 26);
            this.label2.TabIndex = 24;
            this.label2.Text = "Date d\'installation du SE : ";
            // 
            // txtTeamViewer
            // 
            this.txtTeamViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeamViewer.Location = new System.Drawing.Point(302, 356);
            this.txtTeamViewer.Margin = new System.Windows.Forms.Padding(6);
            this.txtTeamViewer.Name = "txtTeamViewer";
            this.txtTeamViewer.ReadOnly = true;
            this.txtTeamViewer.Size = new System.Drawing.Size(196, 34);
            this.txtTeamViewer.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 362);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 26);
            this.label3.TabIndex = 26;
            this.label3.Text = "TeamViewer :";
            // 
            // txtIPE
            // 
            this.txtIPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPE.Location = new System.Drawing.Point(1186, 120);
            this.txtIPE.Margin = new System.Windows.Forms.Padding(6);
            this.txtIPE.Name = "txtIPE";
            this.txtIPE.ReadOnly = true;
            this.txtIPE.Size = new System.Drawing.Size(196, 34);
            this.txtIPE.TabIndex = 27;
            // 
            // txtIPW
            // 
            this.txtIPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPW.Location = new System.Drawing.Point(1186, 168);
            this.txtIPW.Margin = new System.Windows.Forms.Padding(6);
            this.txtIPW.Name = "txtIPW";
            this.txtIPW.ReadOnly = true;
            this.txtIPW.Size = new System.Drawing.Size(196, 34);
            this.txtIPW.TabIndex = 28;
            // 
            // txtDHCP
            // 
            this.txtDHCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDHCP.Location = new System.Drawing.Point(1186, 220);
            this.txtDHCP.Margin = new System.Windows.Forms.Padding(6);
            this.txtDHCP.Name = "txtDHCP";
            this.txtDHCP.ReadOnly = true;
            this.txtDHCP.Size = new System.Drawing.Size(196, 34);
            this.txtDHCP.TabIndex = 29;
            // 
            // txtLastReboot
            // 
            this.txtLastReboot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastReboot.Location = new System.Drawing.Point(1186, 268);
            this.txtLastReboot.Margin = new System.Windows.Forms.Padding(6);
            this.txtLastReboot.Name = "txtLastReboot";
            this.txtLastReboot.ReadOnly = true;
            this.txtLastReboot.Size = new System.Drawing.Size(196, 34);
            this.txtLastReboot.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(888, 372);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 26);
            this.label4.TabIndex = 31;
            this.label4.Text = "Capacité Disque dur (Go) :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(888, 432);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 26);
            this.label5.TabIndex = 32;
            this.label5.Text = "Espace libre restant (%) :";
            // 
            // txtStoragePrct
            // 
            this.txtStoragePrct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStoragePrct.Location = new System.Drawing.Point(1186, 424);
            this.txtStoragePrct.Margin = new System.Windows.Forms.Padding(6);
            this.txtStoragePrct.Name = "txtStoragePrct";
            this.txtStoragePrct.ReadOnly = true;
            this.txtStoragePrct.Size = new System.Drawing.Size(196, 34);
            this.txtStoragePrct.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(888, 268);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 26);
            this.label6.TabIndex = 34;
            this.label6.Text = "Dernier reboot (en jour) : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(888, 224);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 26);
            this.label7.TabIndex = 35;
            this.label7.Text = "DHCP :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(888, 172);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 26);
            this.label8.TabIndex = 36;
            this.label8.Text = "IP Wifi :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(888, 124);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 26);
            this.label9.TabIndex = 37;
            this.label9.Text = "Ethernet";
            // 
            // enregistrement
            // 
            this.enregistrement.Location = new System.Drawing.Point(302, 812);
            this.enregistrement.Margin = new System.Windows.Forms.Padding(6);
            this.enregistrement.Name = "enregistrement";
            this.enregistrement.Size = new System.Drawing.Size(194, 44);
            this.enregistrement.TabIndex = 38;
            this.enregistrement.Text = "Enregistrer";
            this.enregistrement.UseVisualStyleBackColor = true;
            this.enregistrement.Click += new System.EventHandler(this.enregistrement_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(984, 504);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(400, 352);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(124, 302);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(146, 26);
            this.label17.TabIndex = 7;
            this.label17.Text = "09 72 50 59 75";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(142, 266);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 29);
            this.label16.TabIndex = 6;
            this.label16.Text = "Standard";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(124, 220);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(146, 26);
            this.label15.TabIndex = 5;
            this.label15.Text = "09 72 17 66 00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(66, 186);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(255, 26);
            this.label14.TabIndex = 4;
            this.label14.Text = "commerce@one-system.fr";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(90, 158);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(226, 29);
            this.label13.TabIndex = 3;
            this.label13.Text = "Support Commercial";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 104);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 26);
            this.label12.TabIndex = 2;
            this.label12.Text = "09 72 52 05 46";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(64, 68);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(250, 26);
            this.label11.TabIndex = 1;
            this.label11.Text = "technique@one-system.fr";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(104, 34);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 29);
            this.label10.TabIndex = 0;
            this.label10.Text = "Support Technique";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 356);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 44);
            this.button1.TabIndex = 40;
            this.button1.Text = "Installer TeamViewer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myostool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1426, 892);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.enregistrement);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStoragePrct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastReboot);
            this.Controls.Add(this.txtDHCP);
            this.Controls.Add(this.txtIPW);
            this.Controls.Add(this.txtIPE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTeamViewer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tab3);
            this.Controls.Add(this.txtInstallDate);
            this.Controls.Add(this.txtOS);
            this.Controls.Add(this.antivirus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Proc);
            this.Controls.Add(this.SerialNumber);
            this.Controls.Add(this.model);
            this.Controls.Add(this.Manufacturer);
            this.Controls.Add(this.Tab2);
            this.Controls.Add(this.OSVersion);
            this.Controls.Add(this.SystemOS);
            this.Controls.Add(this.pcname);
            this.Controls.Add(this.Tab1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAntivirus);
            this.Controls.Add(this.txtStorage);
            this.Controls.Add(this.txtMemory);
            this.Controls.Add(this.txtProcessor);
            this.Controls.Add(this.txtOsVersion);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.btnGetInfo);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "myostool";
            this.Text = "MyOS Tools V2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.TextBox txtOsVersion;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtMemory;
        private System.Windows.Forms.TextBox txtProcessor;
        private System.Windows.Forms.TextBox txtAntivirus;
        private System.Windows.Forms.TextBox txtStorage;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label Tab1;
        private System.Windows.Forms.Label pcname;
        private System.Windows.Forms.Label SystemOS;
        private System.Windows.Forms.Label OSVersion;
        private System.Windows.Forms.Label Tab2;
        private System.Windows.Forms.Label Manufacturer;
        private System.Windows.Forms.Label model;
        private System.Windows.Forms.Label SerialNumber;
        private System.Windows.Forms.Label Proc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label antivirus;
        public System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.TextBox txtInstallDate;
        private System.Windows.Forms.Label Tab3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTeamViewer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIPE;
        private System.Windows.Forms.TextBox txtIPW;
        private System.Windows.Forms.TextBox txtDHCP;
        private System.Windows.Forms.TextBox txtLastReboot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStoragePrct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button enregistrement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
    }
}

