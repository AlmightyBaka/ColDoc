namespace ColDoc
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonCreate = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.labelTheme = new System.Windows.Forms.Label();
			this.textBoxTheme = new System.Windows.Forms.TextBox();
			this.labelNumber = new System.Windows.Forms.Label();
			this.textBoxProjectsPath = new System.Windows.Forms.TextBox();
			this.textBoxFilePath = new System.Windows.Forms.TextBox();
			this.numericUpDownDocumentNumber = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonProjectsPath = new System.Windows.Forms.Button();
			this.buttonFilePath = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.checkBoxMakeScreenshot = new System.Windows.Forms.CheckBox();
			this.checkBoxOpenAfterCreate = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDocumentNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCreate
			// 
			this.buttonCreate.Location = new System.Drawing.Point(12, 338);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(113, 23);
			this.buttonCreate.TabIndex = 0;
			this.buttonCreate.Text = "Создать документ";
			this.buttonCreate.UseVisualStyleBackColor = true;
			this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// labelTheme
			// 
			this.labelTheme.AutoSize = true;
			this.labelTheme.Location = new System.Drawing.Point(12, 59);
			this.labelTheme.Name = "labelTheme";
			this.labelTheme.Size = new System.Drawing.Size(37, 13);
			this.labelTheme.TabIndex = 2;
			this.labelTheme.Text = "Тема:";
			// 
			// textBoxTheme
			// 
			this.textBoxTheme.Location = new System.Drawing.Point(90, 56);
			this.textBoxTheme.Name = "textBoxTheme";
			this.textBoxTheme.Size = new System.Drawing.Size(190, 20);
			this.textBoxTheme.TabIndex = 3;
			this.textBoxTheme.Text = "theme";
			// 
			// labelNumber
			// 
			this.labelNumber.AutoSize = true;
			this.labelNumber.Location = new System.Drawing.Point(12, 86);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(44, 13);
			this.labelNumber.TabIndex = 4;
			this.labelNumber.Text = "Номер:";
			// 
			// textBoxProjectsPath
			// 
			this.textBoxProjectsPath.Location = new System.Drawing.Point(90, 6);
			this.textBoxProjectsPath.Name = "textBoxProjectsPath";
			this.textBoxProjectsPath.Size = new System.Drawing.Size(277, 20);
			this.textBoxProjectsPath.TabIndex = 6;
			this.textBoxProjectsPath.Text = "E:\\College\\ТА\\8_Решение СЛУ";
			// 
			// textBoxFilePath
			// 
			this.textBoxFilePath.Location = new System.Drawing.Point(90, 30);
			this.textBoxFilePath.Name = "textBoxFilePath";
			this.textBoxFilePath.Size = new System.Drawing.Size(277, 20);
			this.textBoxFilePath.TabIndex = 7;
			this.textBoxFilePath.Text = "E:\\Code\\C#\\ColDoc\\Docs\\ЛР0_name_theme";
			// 
			// numericUpDownDocumentNumber
			// 
			this.numericUpDownDocumentNumber.Location = new System.Drawing.Point(90, 84);
			this.numericUpDownDocumentNumber.Name = "numericUpDownDocumentNumber";
			this.numericUpDownDocumentNumber.Size = new System.Drawing.Size(48, 20);
			this.numericUpDownDocumentNumber.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Проекты:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Сохранить в:";
			// 
			// buttonProjectsPath
			// 
			this.buttonProjectsPath.Location = new System.Drawing.Point(373, 6);
			this.buttonProjectsPath.Name = "buttonProjectsPath";
			this.buttonProjectsPath.Size = new System.Drawing.Size(75, 20);
			this.buttonProjectsPath.TabIndex = 11;
			this.buttonProjectsPath.Text = "Выбрать...";
			this.buttonProjectsPath.UseVisualStyleBackColor = true;
			this.buttonProjectsPath.Click += new System.EventHandler(this.buttonSelectProjects_Click);
			// 
			// buttonFilePath
			// 
			this.buttonFilePath.Location = new System.Drawing.Point(373, 30);
			this.buttonFilePath.Name = "buttonFilePath";
			this.buttonFilePath.Size = new System.Drawing.Size(75, 20);
			this.buttonFilePath.TabIndex = 12;
			this.buttonFilePath.Text = "Выбрать...";
			this.buttonFilePath.UseVisualStyleBackColor = true;
			this.buttonFilePath.Click += new System.EventHandler(this.buttonFilePath_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 114);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Фамилия";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(90, 111);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(100, 20);
			this.textBoxName.TabIndex = 14;
			this.textBoxName.Text = "name";
			// 
			// checkBoxMakeScreenshot
			// 
			this.checkBoxMakeScreenshot.AutoSize = true;
			this.checkBoxMakeScreenshot.Location = new System.Drawing.Point(371, 342);
			this.checkBoxMakeScreenshot.Name = "checkBoxMakeScreenshot";
			this.checkBoxMakeScreenshot.Size = new System.Drawing.Size(76, 17);
			this.checkBoxMakeScreenshot.TabIndex = 15;
			this.checkBoxMakeScreenshot.Text = "Скриншот";
			this.checkBoxMakeScreenshot.UseVisualStyleBackColor = true;
			// 
			// checkBoxOpenAfterCreate
			// 
			this.checkBoxOpenAfterCreate.AutoSize = true;
			this.checkBoxOpenAfterCreate.Checked = true;
			this.checkBoxOpenAfterCreate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxOpenAfterCreate.Location = new System.Drawing.Point(371, 319);
			this.checkBoxOpenAfterCreate.Name = "checkBoxOpenAfterCreate";
			this.checkBoxOpenAfterCreate.Size = new System.Drawing.Size(70, 17);
			this.checkBoxOpenAfterCreate.TabIndex = 16;
			this.checkBoxOpenAfterCreate.Text = "Открыть";
			this.checkBoxOpenAfterCreate.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 373);
			this.Controls.Add(this.checkBoxOpenAfterCreate);
			this.Controls.Add(this.checkBoxMakeScreenshot);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonFilePath);
			this.Controls.Add(this.buttonProjectsPath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDownDocumentNumber);
			this.Controls.Add(this.textBoxFilePath);
			this.Controls.Add(this.textBoxProjectsPath);
			this.Controls.Add(this.labelNumber);
			this.Controls.Add(this.textBoxTheme);
			this.Controls.Add(this.labelTheme);
			this.Controls.Add(this.buttonCreate);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDocumentNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label labelTheme;
		private System.Windows.Forms.TextBox textBoxTheme;
		private System.Windows.Forms.Label labelNumber;
		private System.Windows.Forms.TextBox textBoxProjectsPath;
		private System.Windows.Forms.TextBox textBoxFilePath;
		private System.Windows.Forms.NumericUpDown numericUpDownDocumentNumber;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonProjectsPath;
		private System.Windows.Forms.Button buttonFilePath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.CheckBox checkBoxMakeScreenshot;
		private System.Windows.Forms.CheckBox checkBoxOpenAfterCreate;
	}
}

