namespace IntercomSimulator
{
    partial class MainFormIntercomSimulator
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxListenerData = new System.Windows.Forms.TextBox();
            this.buttonSendDataToPhone = new System.Windows.Forms.Button();
            this.textBoxSendToPhone = new System.Windows.Forms.TextBox();
            this.labelPhoneListenerOpenedConnections = new System.Windows.Forms.Label();
            this.textBoxEndOfMessageTag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxListenerPort = new System.Windows.Forms.TextBox();
            this.labelListenerPort = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.textBoxListenerIPAddress = new System.Windows.Forms.TextBox();
            this.labelListenerStatus = new System.Windows.Forms.Label();
            this.labelOpenedConnections = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.buttonPhoneStartListening = new System.Windows.Forms.Button();
            this.labelURL = new System.Windows.Forms.Label();
            this.textBoxHttpURL = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxSpeakerUDP = new System.Windows.Forms.CheckBox();
            this.checkBoxListenerUDP = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxListenerBufferSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSepeakerIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSpeakerPort = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.labelBytesPerSecond = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSizeOfConsumptionBuffer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSizeOfReceptionBuffer = new System.Windows.Forms.TextBox();
            this.comboBoxAudioDeviceIn = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.audioCaptureButton = new System.Windows.Forms.Button();
            this.labelAudioCaptureStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxAudioCaptureRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAudioCaptureBits = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAudioCaptureChannels = new System.Windows.Forms.TextBox();
            this.textBoxAudioFileName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonAudioSave = new System.Windows.Forms.Button();
            this.labelAudioSaveStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxAudioDeviceOut = new System.Windows.Forms.ComboBox();
            this.labelAudioPlayStatus = new System.Windows.Forms.Label();
            this.buttonAudioPlay = new System.Windows.Forms.Button();
            this.labelByteArrayAnalysis = new System.Windows.Forms.Label();
            this.textBoxSaveAudioTime = new System.Windows.Forms.TextBox();
            this.LabelSaveAudioSeconds = new System.Windows.Forms.Label();
            this.timerAudioSaveSeconds = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(174, 257);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(72, 20);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "STATUS";
            this.labelStatus.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // textBoxListenerData
            // 
            this.textBoxListenerData.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBoxListenerData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxListenerData.ForeColor = System.Drawing.Color.Black;
            this.textBoxListenerData.Location = new System.Drawing.Point(15, 297);
            this.textBoxListenerData.Multiline = true;
            this.textBoxListenerData.Name = "textBoxListenerData";
            this.textBoxListenerData.ReadOnly = true;
            this.textBoxListenerData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxListenerData.Size = new System.Drawing.Size(501, 299);
            this.textBoxListenerData.TabIndex = 2;
            // 
            // buttonSendDataToPhone
            // 
            this.buttonSendDataToPhone.Image = global::IntercomSimulator.Resources.PlayIcon;
            this.buttonSendDataToPhone.Location = new System.Drawing.Point(547, 230);
            this.buttonSendDataToPhone.Name = "buttonSendDataToPhone";
            this.buttonSendDataToPhone.Size = new System.Drawing.Size(53, 54);
            this.buttonSendDataToPhone.TabIndex = 3;
            this.buttonSendDataToPhone.UseVisualStyleBackColor = true;
            this.buttonSendDataToPhone.Click += new System.EventHandler(this.buttonSendDataToPhone_Click);
            // 
            // textBoxSendToPhone
            // 
            this.textBoxSendToPhone.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxSendToPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSendToPhone.Location = new System.Drawing.Point(547, 297);
            this.textBoxSendToPhone.Multiline = true;
            this.textBoxSendToPhone.Name = "textBoxSendToPhone";
            this.textBoxSendToPhone.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSendToPhone.Size = new System.Drawing.Size(514, 299);
            this.textBoxSendToPhone.TabIndex = 4;
            // 
            // labelPhoneListenerOpenedConnections
            // 
            this.labelPhoneListenerOpenedConnections.AutoSize = true;
            this.labelPhoneListenerOpenedConnections.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhoneListenerOpenedConnections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelPhoneListenerOpenedConnections.Location = new System.Drawing.Point(207, 229);
            this.labelPhoneListenerOpenedConnections.Name = "labelPhoneListenerOpenedConnections";
            this.labelPhoneListenerOpenedConnections.Size = new System.Drawing.Size(188, 24);
            this.labelPhoneListenerOpenedConnections.TabIndex = 5;
            this.labelPhoneListenerOpenedConnections.Text = "Opened connections";
            this.labelPhoneListenerOpenedConnections.Click += new System.EventHandler(this.labelPhoneListenerOpenedConnections_Click);
            // 
            // textBoxEndOfMessageTag
            // 
            this.textBoxEndOfMessageTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEndOfMessageTag.Location = new System.Drawing.Point(917, 230);
            this.textBoxEndOfMessageTag.Name = "textBoxEndOfMessageTag";
            this.textBoxEndOfMessageTag.Size = new System.Drawing.Size(142, 29);
            this.textBoxEndOfMessageTag.TabIndex = 6;
            this.textBoxEndOfMessageTag.TextChanged += new System.EventHandler(this.textBoxEndOfMessageTag_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(680, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Marca de final de mensaje";
            // 
            // textBoxListenerPort
            // 
            this.textBoxListenerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxListenerPort.Location = new System.Drawing.Point(443, 147);
            this.textBoxListenerPort.Name = "textBoxListenerPort";
            this.textBoxListenerPort.Size = new System.Drawing.Size(77, 29);
            this.textBoxListenerPort.TabIndex = 10;
            this.textBoxListenerPort.Text = "8081";
            this.textBoxListenerPort.TextChanged += new System.EventHandler(this.textBoxListenerPort_TextChanged);
            // 
            // labelListenerPort
            // 
            this.labelListenerPort.AutoSize = true;
            this.labelListenerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListenerPort.Location = new System.Drawing.Point(358, 147);
            this.labelListenerPort.Name = "labelListenerPort";
            this.labelListenerPort.Size = new System.Drawing.Size(65, 24);
            this.labelListenerPort.TabIndex = 11;
            this.labelListenerPort.Text = "Puerto";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIPAddress.Location = new System.Drawing.Point(12, 147);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(111, 24);
            this.labelIPAddress.TabIndex = 13;
            this.labelIPAddress.Text = "Direccion IP";
            // 
            // textBoxListenerIPAddress
            // 
            this.textBoxListenerIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxListenerIPAddress.Location = new System.Drawing.Point(141, 147);
            this.textBoxListenerIPAddress.Name = "textBoxListenerIPAddress";
            this.textBoxListenerIPAddress.Size = new System.Drawing.Size(159, 29);
            this.textBoxListenerIPAddress.TabIndex = 12;
            this.textBoxListenerIPAddress.Text = "192.168.1.43";
            this.textBoxListenerIPAddress.TextChanged += new System.EventHandler(this.textBoxIPAddress_TextChanged);
            // 
            // labelListenerStatus
            // 
            this.labelListenerStatus.AutoSize = true;
            this.labelListenerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListenerStatus.Location = new System.Drawing.Point(86, 251);
            this.labelListenerStatus.Name = "labelListenerStatus";
            this.labelListenerStatus.Size = new System.Drawing.Size(68, 24);
            this.labelListenerStatus.TabIndex = 14;
            this.labelListenerStatus.Text = "Estado";
            this.labelListenerStatus.Click += new System.EventHandler(this.labelListenerStatus_Click);
            // 
            // labelOpenedConnections
            // 
            this.labelOpenedConnections.AutoSize = true;
            this.labelOpenedConnections.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpenedConnections.Location = new System.Drawing.Point(85, 229);
            this.labelOpenedConnections.Name = "labelOpenedConnections";
            this.labelOpenedConnections.Size = new System.Drawing.Size(112, 24);
            this.labelOpenedConnections.TabIndex = 15;
            this.labelOpenedConnections.Text = "Conexiones";
            this.labelOpenedConnections.Click += new System.EventHandler(this.labelOpenedConnections_Click);
            // 
            // Logo
            // 
            this.Logo.Image = global::IntercomSimulator.Resources.CacaLogo;
            this.Logo.Location = new System.Drawing.Point(20, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(166, 59);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 8;
            this.Logo.TabStop = false;
            // 
            // buttonPhoneStartListening
            // 
            this.buttonPhoneStartListening.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPhoneStartListening.Image = global::IntercomSimulator.Resources.PlayIcon;
            this.buttonPhoneStartListening.Location = new System.Drawing.Point(15, 229);
            this.buttonPhoneStartListening.Name = "buttonPhoneStartListening";
            this.buttonPhoneStartListening.Size = new System.Drawing.Size(53, 54);
            this.buttonPhoneStartListening.TabIndex = 0;
            this.buttonPhoneStartListening.UseVisualStyleBackColor = true;
            this.buttonPhoneStartListening.Click += new System.EventHandler(this.buttonPhoneStartListening_Click);
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelURL.Location = new System.Drawing.Point(549, 185);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(81, 24);
            this.labelURL.TabIndex = 18;
            this.labelURL.Text = "URL http";
            // 
            // textBoxHttpURL
            // 
            this.textBoxHttpURL.Font = new System.Drawing.Font("Maiandra GD", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHttpURL.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBoxHttpURL.Location = new System.Drawing.Point(655, 182);
            this.textBoxHttpURL.Name = "textBoxHttpURL";
            this.textBoxHttpURL.Size = new System.Drawing.Size(404, 30);
            this.textBoxHttpURL.TabIndex = 17;
            this.textBoxHttpURL.Text = "http://192.168.1.8:11000/";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IntercomSimulator.Resources.CacaLogo;
            this.pictureBox1.Location = new System.Drawing.Point(557, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxSpeakerUDP
            // 
            this.checkBoxSpeakerUDP.AutoSize = true;
            this.checkBoxSpeakerUDP.Checked = true;
            this.checkBoxSpeakerUDP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSpeakerUDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.checkBoxSpeakerUDP.Location = new System.Drawing.Point(557, 114);
            this.checkBoxSpeakerUDP.Name = "checkBoxSpeakerUDP";
            this.checkBoxSpeakerUDP.Size = new System.Drawing.Size(67, 28);
            this.checkBoxSpeakerUDP.TabIndex = 21;
            this.checkBoxSpeakerUDP.Text = "UDP";
            this.checkBoxSpeakerUDP.UseVisualStyleBackColor = true;
            this.checkBoxSpeakerUDP.CheckedChanged += new System.EventHandler(this.checkBoxSpeakerUDP_CheckedChanged);
            // 
            // checkBoxListenerUDP
            // 
            this.checkBoxListenerUDP.AutoSize = true;
            this.checkBoxListenerUDP.Checked = true;
            this.checkBoxListenerUDP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxListenerUDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.checkBoxListenerUDP.Location = new System.Drawing.Point(20, 114);
            this.checkBoxListenerUDP.Name = "checkBoxListenerUDP";
            this.checkBoxListenerUDP.Size = new System.Drawing.Size(67, 28);
            this.checkBoxListenerUDP.TabIndex = 22;
            this.checkBoxListenerUDP.Text = "UDP";
            this.checkBoxListenerUDP.UseVisualStyleBackColor = true;
            this.checkBoxListenerUDP.CheckedChanged += new System.EventHandler(this.checkBoxListenerUDP_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(231, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tamaño del buffer UDP";
            // 
            // textBoxListenerBufferSize
            // 
            this.textBoxListenerBufferSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxListenerBufferSize.Location = new System.Drawing.Point(443, 114);
            this.textBoxListenerBufferSize.Name = "textBoxListenerBufferSize";
            this.textBoxListenerBufferSize.Size = new System.Drawing.Size(77, 29);
            this.textBoxListenerBufferSize.TabIndex = 23;
            this.textBoxListenerBufferSize.Text = "10000";
            this.textBoxListenerBufferSize.TextChanged += new System.EventHandler(this.textBoxListenerBufferSize_TextChanged);
            this.textBoxListenerBufferSize.Validated += new System.EventHandler(this.textBoxListenerBufferSize_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(549, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "Direccion IP";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxSepeakerIPAddress
            // 
            this.textBoxSepeakerIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSepeakerIPAddress.Location = new System.Drawing.Point(675, 147);
            this.textBoxSepeakerIPAddress.Name = "textBoxSepeakerIPAddress";
            this.textBoxSepeakerIPAddress.Size = new System.Drawing.Size(159, 29);
            this.textBoxSepeakerIPAddress.TabIndex = 27;
            this.textBoxSepeakerIPAddress.Text = "192.168.1.43";
            this.textBoxSepeakerIPAddress.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(897, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "Puerto";
            // 
            // textBoxSpeakerPort
            // 
            this.textBoxSpeakerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSpeakerPort.Location = new System.Drawing.Point(982, 147);
            this.textBoxSpeakerPort.Name = "textBoxSpeakerPort";
            this.textBoxSpeakerPort.Size = new System.Drawing.Size(77, 29);
            this.textBoxSpeakerPort.TabIndex = 25;
            this.textBoxSpeakerPort.Text = "8081";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Detener escucha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // labelBytesPerSecond
            // 
            this.labelBytesPerSecond.AutoSize = true;
            this.labelBytesPerSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBytesPerSecond.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelBytesPerSecond.Location = new System.Drawing.Point(89, 277);
            this.labelBytesPerSecond.Name = "labelBytesPerSecond";
            this.labelBytesPerSecond.Size = new System.Drawing.Size(97, 15);
            this.labelBytesPerSecond.TabIndex = 30;
            this.labelBytesPerSecond.Text = "BytesPerSecond";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(295, 615);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Consumo del buffer";
            // 
            // textBoxSizeOfConsumptionBuffer
            // 
            this.textBoxSizeOfConsumptionBuffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSizeOfConsumptionBuffer.Location = new System.Drawing.Point(432, 612);
            this.textBoxSizeOfConsumptionBuffer.Name = "textBoxSizeOfConsumptionBuffer";
            this.textBoxSizeOfConsumptionBuffer.Size = new System.Drawing.Size(77, 23);
            this.textBoxSizeOfConsumptionBuffer.TabIndex = 31;
            this.textBoxSizeOfConsumptionBuffer.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 612);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Buffer de recepción";
            // 
            // textBoxSizeOfReceptionBuffer
            // 
            this.textBoxSizeOfReceptionBuffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSizeOfReceptionBuffer.Location = new System.Drawing.Point(143, 612);
            this.textBoxSizeOfReceptionBuffer.Name = "textBoxSizeOfReceptionBuffer";
            this.textBoxSizeOfReceptionBuffer.Size = new System.Drawing.Size(77, 23);
            this.textBoxSizeOfReceptionBuffer.TabIndex = 33;
            this.textBoxSizeOfReceptionBuffer.Text = "30000";
            // 
            // comboBoxAudioDeviceIn
            // 
            this.comboBoxAudioDeviceIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAudioDeviceIn.FormattingEnabled = true;
            this.comboBoxAudioDeviceIn.Location = new System.Drawing.Point(712, 656);
            this.comboBoxAudioDeviceIn.Name = "comboBoxAudioDeviceIn";
            this.comboBoxAudioDeviceIn.Size = new System.Drawing.Size(336, 32);
            this.comboBoxAudioDeviceIn.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(552, 658);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 24);
            this.label7.TabIndex = 36;
            this.label7.Text = "Entrada de audio";
            // 
            // audioCaptureButton
            // 
            this.audioCaptureButton.Location = new System.Drawing.Point(546, 602);
            this.audioCaptureButton.Name = "audioCaptureButton";
            this.audioCaptureButton.Size = new System.Drawing.Size(151, 23);
            this.audioCaptureButton.TabIndex = 37;
            this.audioCaptureButton.Text = "Capturar audio";
            this.audioCaptureButton.UseVisualStyleBackColor = true;
            this.audioCaptureButton.Click += new System.EventHandler(this.audioCaptureButton_Click);
            // 
            // labelAudioCaptureStatus
            // 
            this.labelAudioCaptureStatus.AutoSize = true;
            this.labelAudioCaptureStatus.ForeColor = System.Drawing.Color.Blue;
            this.labelAudioCaptureStatus.Location = new System.Drawing.Point(709, 607);
            this.labelAudioCaptureStatus.Name = "labelAudioCaptureStatus";
            this.labelAudioCaptureStatus.Size = new System.Drawing.Size(35, 13);
            this.labelAudioCaptureStatus.TabIndex = 38;
            this.labelAudioCaptureStatus.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(631, 627);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 40;
            this.label8.Text = "Hz. (Frec.)";
            // 
            // textBoxAudioCaptureRate
            // 
            this.textBoxAudioCaptureRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAudioCaptureRate.Location = new System.Drawing.Point(712, 627);
            this.textBoxAudioCaptureRate.Name = "textBoxAudioCaptureRate";
            this.textBoxAudioCaptureRate.Size = new System.Drawing.Size(58, 23);
            this.textBoxAudioCaptureRate.TabIndex = 39;
            this.textBoxAudioCaptureRate.Text = "8000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(776, 630);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "Bits";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBoxAudioCaptureBits
            // 
            this.textBoxAudioCaptureBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAudioCaptureBits.Location = new System.Drawing.Point(813, 627);
            this.textBoxAudioCaptureBits.Name = "textBoxAudioCaptureBits";
            this.textBoxAudioCaptureBits.Size = new System.Drawing.Size(31, 23);
            this.textBoxAudioCaptureBits.TabIndex = 41;
            this.textBoxAudioCaptureBits.Text = "8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(845, 630);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 44;
            this.label10.Text = "Canales";
            // 
            // textBoxAudioCaptureChannels
            // 
            this.textBoxAudioCaptureChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAudioCaptureChannels.Location = new System.Drawing.Point(910, 627);
            this.textBoxAudioCaptureChannels.Name = "textBoxAudioCaptureChannels";
            this.textBoxAudioCaptureChannels.Size = new System.Drawing.Size(31, 23);
            this.textBoxAudioCaptureChannels.TabIndex = 43;
            this.textBoxAudioCaptureChannels.Text = "1";
            // 
            // textBoxAudioFileName
            // 
            this.textBoxAudioFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAudioFileName.Location = new System.Drawing.Point(235, 665);
            this.textBoxAudioFileName.Name = "textBoxAudioFileName";
            this.textBoxAudioFileName.Size = new System.Drawing.Size(274, 23);
            this.textBoxAudioFileName.TabIndex = 46;
            this.textBoxAudioFileName.Text = "C:\\PruebasDeSonido\\InterComAudio{0}.{1}";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(175, 665);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 17);
            this.label11.TabIndex = 47;
            this.label11.Text = "Fichero";
            // 
            // buttonAudioSave
            // 
            this.buttonAudioSave.Location = new System.Drawing.Point(10, 656);
            this.buttonAudioSave.Name = "buttonAudioSave";
            this.buttonAudioSave.Size = new System.Drawing.Size(151, 23);
            this.buttonAudioSave.TabIndex = 48;
            this.buttonAudioSave.Text = "Grabar audio";
            this.buttonAudioSave.UseVisualStyleBackColor = true;
            this.buttonAudioSave.Click += new System.EventHandler(this.buttonAudioSave_Click);
            // 
            // labelAudioSaveStatus
            // 
            this.labelAudioSaveStatus.AutoSize = true;
            this.labelAudioSaveStatus.ForeColor = System.Drawing.Color.Blue;
            this.labelAudioSaveStatus.Location = new System.Drawing.Point(232, 649);
            this.labelAudioSaveStatus.Name = "labelAudioSaveStatus";
            this.labelAudioSaveStatus.Size = new System.Drawing.Size(35, 13);
            this.labelAudioSaveStatus.TabIndex = 49;
            this.labelAudioSaveStatus.Text = "label8";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 723);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 24);
            this.label12.TabIndex = 51;
            this.label12.Text = "Salida de audio";
            // 
            // comboBoxAudioDeviceOut
            // 
            this.comboBoxAudioDeviceOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAudioDeviceOut.FormattingEnabled = true;
            this.comboBoxAudioDeviceOut.Location = new System.Drawing.Point(171, 721);
            this.comboBoxAudioDeviceOut.Name = "comboBoxAudioDeviceOut";
            this.comboBoxAudioDeviceOut.Size = new System.Drawing.Size(336, 32);
            this.comboBoxAudioDeviceOut.TabIndex = 50;
            // 
            // labelAudioPlayStatus
            // 
            this.labelAudioPlayStatus.AutoSize = true;
            this.labelAudioPlayStatus.ForeColor = System.Drawing.Color.Blue;
            this.labelAudioPlayStatus.Location = new System.Drawing.Point(173, 702);
            this.labelAudioPlayStatus.Name = "labelAudioPlayStatus";
            this.labelAudioPlayStatus.Size = new System.Drawing.Size(35, 13);
            this.labelAudioPlayStatus.TabIndex = 53;
            this.labelAudioPlayStatus.Text = "label8";
            // 
            // buttonAudioPlay
            // 
            this.buttonAudioPlay.Location = new System.Drawing.Point(10, 697);
            this.buttonAudioPlay.Name = "buttonAudioPlay";
            this.buttonAudioPlay.Size = new System.Drawing.Size(151, 23);
            this.buttonAudioPlay.TabIndex = 52;
            this.buttonAudioPlay.Text = "Reproducir audio";
            this.buttonAudioPlay.UseVisualStyleBackColor = true;
            this.buttonAudioPlay.Click += new System.EventHandler(this.buttonAudioPlay_Click);
            // 
            // labelByteArrayAnalysis
            // 
            this.labelByteArrayAnalysis.AutoSize = true;
            this.labelByteArrayAnalysis.ForeColor = System.Drawing.Color.Blue;
            this.labelByteArrayAnalysis.Location = new System.Drawing.Point(709, 702);
            this.labelByteArrayAnalysis.Name = "labelByteArrayAnalysis";
            this.labelByteArrayAnalysis.Size = new System.Drawing.Size(35, 13);
            this.labelByteArrayAnalysis.TabIndex = 54;
            this.labelByteArrayAnalysis.Text = "label8";
            // 
            // textBoxSaveAudioTime
            // 
            this.textBoxSaveAudioTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaveAudioTime.Location = new System.Drawing.Point(10, 632);
            this.textBoxSaveAudioTime.Name = "textBoxSaveAudioTime";
            this.textBoxSaveAudioTime.Size = new System.Drawing.Size(60, 23);
            this.textBoxSaveAudioTime.TabIndex = 55;
            this.textBoxSaveAudioTime.Text = "0";
            // 
            // LabelSaveAudioSeconds
            // 
            this.LabelSaveAudioSeconds.AutoSize = true;
            this.LabelSaveAudioSeconds.ForeColor = System.Drawing.Color.Blue;
            this.LabelSaveAudioSeconds.Location = new System.Drawing.Point(76, 640);
            this.LabelSaveAudioSeconds.Name = "LabelSaveAudioSeconds";
            this.LabelSaveAudioSeconds.Size = new System.Drawing.Size(110, 13);
            this.LabelSaveAudioSeconds.TabIndex = 56;
            this.LabelSaveAudioSeconds.Text = "Milisegundos a grabar";
            // 
            // timerAudioSaveSeconds
            // 
            this.timerAudioSaveSeconds.Interval = 1000;
            this.timerAudioSaveSeconds.Tick += new System.EventHandler(this.timerAudioSaveSeconds_Tick);
            // 
            // MainFormIntercomSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 770);
            this.Controls.Add(this.LabelSaveAudioSeconds);
            this.Controls.Add(this.textBoxSaveAudioTime);
            this.Controls.Add(this.labelByteArrayAnalysis);
            this.Controls.Add(this.labelAudioPlayStatus);
            this.Controls.Add(this.buttonAudioPlay);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxAudioDeviceOut);
            this.Controls.Add(this.labelAudioSaveStatus);
            this.Controls.Add(this.buttonAudioSave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxAudioFileName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxAudioCaptureChannels);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxAudioCaptureBits);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxAudioCaptureRate);
            this.Controls.Add(this.labelAudioCaptureStatus);
            this.Controls.Add(this.audioCaptureButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxAudioDeviceIn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSizeOfReceptionBuffer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxSizeOfConsumptionBuffer);
            this.Controls.Add(this.labelBytesPerSecond);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSepeakerIPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSpeakerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxListenerBufferSize);
            this.Controls.Add(this.checkBoxListenerUDP);
            this.Controls.Add(this.checkBoxSpeakerUDP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.textBoxHttpURL);
            this.Controls.Add(this.labelOpenedConnections);
            this.Controls.Add(this.labelListenerStatus);
            this.Controls.Add(this.labelIPAddress);
            this.Controls.Add(this.textBoxListenerIPAddress);
            this.Controls.Add(this.labelListenerPort);
            this.Controls.Add(this.textBoxListenerPort);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEndOfMessageTag);
            this.Controls.Add(this.labelPhoneListenerOpenedConnections);
            this.Controls.Add(this.textBoxSendToPhone);
            this.Controls.Add(this.buttonSendDataToPhone);
            this.Controls.Add(this.textBoxListenerData);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonPhoneStartListening);
            this.Name = "MainFormIntercomSimulator";
            this.Text = "Simulador portero automárico";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormIntercomSimulator_FormClosed);
            this.Load += new System.EventHandler(this.MainFormIntercomSimulator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPhoneStartListening;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxListenerData;
        private System.Windows.Forms.Button buttonSendDataToPhone;
        private System.Windows.Forms.TextBox textBoxSendToPhone;
        private System.Windows.Forms.Label labelPhoneListenerOpenedConnections;
        private System.Windows.Forms.TextBox textBoxEndOfMessageTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.TextBox textBoxListenerPort;
        private System.Windows.Forms.Label labelListenerPort;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.TextBox textBoxListenerIPAddress;
        private System.Windows.Forms.Label labelListenerStatus;
        private System.Windows.Forms.Label labelOpenedConnections;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.TextBox textBoxHttpURL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxSpeakerUDP;
        private System.Windows.Forms.CheckBox checkBoxListenerUDP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxListenerBufferSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSepeakerIPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSpeakerPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label labelBytesPerSecond;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSizeOfConsumptionBuffer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSizeOfReceptionBuffer;
        private System.Windows.Forms.ComboBox comboBoxAudioDeviceIn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button audioCaptureButton;
        private System.Windows.Forms.Label labelAudioCaptureStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAudioCaptureRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAudioCaptureBits;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAudioCaptureChannels;
        private System.Windows.Forms.TextBox textBoxAudioFileName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonAudioSave;
        private System.Windows.Forms.Label labelAudioSaveStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxAudioDeviceOut;
        private System.Windows.Forms.Label labelAudioPlayStatus;
        private System.Windows.Forms.Button buttonAudioPlay;
        private System.Windows.Forms.Label labelByteArrayAnalysis;
        private System.Windows.Forms.TextBox textBoxSaveAudioTime;
        private System.Windows.Forms.Label LabelSaveAudioSeconds;
        private System.Windows.Forms.Timer timerAudioSaveSeconds;
    }
}

