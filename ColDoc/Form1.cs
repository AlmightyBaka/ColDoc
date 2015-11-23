using System;
using System.Windows.Forms;

namespace ColDoc
{
	public partial class Form1 : Form
	{
		private string filePath;
		private string projectsPath;
	
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			// filePath = @"E:\Code\C#\CollegeDocs\Docs\Test.docx"
			filePath = $"{textBoxFilePath.Text}\\ЛР{numericUpDownDocumentNumber.Value}_{textBoxName.Text}_{textBoxTheme.Text}.docx";
			Document document = new Document(filePath, (int)numericUpDownDocumentNumber.Value, textBoxTheme.Text);
			document.Create();
		}

		private void buttonSelectProjects_Click(object sender, EventArgs e)
		{
			folderBrowserDialog.Reset();
			folderBrowserDialog.ShowDialog();
			projectsPath = folderBrowserDialog.SelectedPath;
			textBoxProjectsPath.Text = projectsPath;
		}

		private void buttonFilePath_Click(object sender, EventArgs e)
		{
			folderBrowserDialog.Reset();
			folderBrowserDialog.ShowDialog();
			filePath = $"{folderBrowserDialog.SelectedPath}\\ЛР{numericUpDownDocumentNumber.Value}_{textBoxName.Text}_{textBoxTheme.Text}.docx";
			textBoxFilePath.Text = filePath;
		}
	}
}
