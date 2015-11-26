using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ColDoc
{
	public partial class Form1 : Form
	{
		private string fileDir;
		private string projectsDir;
	
		public Form1()
		{
			InitializeComponent();

			string[] browserDialogDir = textBoxFilePath.Text.Split('\\');
			for (int i = 0; i < browserDialogDir.Length - 2; i++)
			{
				folderBrowserDialog.SelectedPath += browserDialogDir[i] + '\\';
			}
			folderBrowserDialog.SelectedPath += browserDialogDir[browserDialogDir.Length - 2];
		}

		private void UpdateFileDir()
		{
			fileDir =
				$"{folderBrowserDialog.SelectedPath}\\ЛР{numericUpDownDocumentNumber.Value}_{textBoxName.Text}_{textBoxTheme.Text}.docx";
			textBoxFilePath.Text = fileDir;
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			fileDir = textBoxFilePath.Text;

			Document document = new Document(textBoxProjectsPath.Text, fileDir, (int)numericUpDownDocumentNumber.Value, textBoxTheme.Text, checkBoxMakeScreenshot.Checked);
			document.Create();
			if (checkBoxOpenAfterCreate.Checked)
			{
				Process.Start("WINWORD.EXE", fileDir);
			}
		}

		private void buttonSelectProjects_Click(object sender, EventArgs e)
		{
			folderBrowserDialog.Reset();
			folderBrowserDialog.ShowDialog();
			projectsDir = folderBrowserDialog.SelectedPath;
			textBoxProjectsPath.Text = projectsDir;
		}

		private void buttonFilePath_Click(object sender, EventArgs e)
		{
			folderBrowserDialog.Reset();
			folderBrowserDialog.ShowDialog();
			UpdateFileDir();
		}

		private void textBoxTheme_TextChanged(object sender, EventArgs e)
		{
			UpdateFileDir();
		}

		private void numericUpDownDocumentNumber_ValueChanged(object sender, EventArgs e)
		{
			UpdateFileDir();
		}
	
		private void textBoxName_TextChanged(object sender, EventArgs e)
		{
			UpdateFileDir();
		}
	}
}
