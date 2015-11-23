// CollegeDocs: Document.cs

using System.Diagnostics;
using Novacode;
using System;
using System.IO;

namespace ColDoc
{
	public class Document
	{
		#region data

		private DocX document;
		private string projectsPath;
		private string filePath;

		private Formatting formattingNormal;
		private Formatting formattingBold;

		private Paragraph paragraphHeader;
		private Paragraph paragraphName;
		private Paragraph paragraphTaskHeader;
		private Paragraph paragraphCodeHeader;
		private Paragraph paragraphCode;
		private Paragraph paragraphResultHeader;
		private Paragraph paragraphDivider;
	
		private string header = "Лабораторная работа №";
		private string taskHeader = "Задание №";
		private string codeHeader = "Текст программы:";
		private string resultHeader = "Результат:";
		private int docNumber;
		private string theme;
		private int taskNumber = 1;
		private string[] codeDirFolders;
		private string[] code;
	
		#endregion

		public Document(string projectsPath, string filePath, int docNumber, string theme)
		{
			//filePath = @"E:\Code\C#\ColDoc\Docs\test.docx";
			//document = DocX.Create(filePath);
			document = DocX.Load(@"E:\Code\C#\ColDoc\Docs\frame.docx");

			this.filePath = filePath;
			this.docNumber = docNumber;
			this.theme = theme;
			this.projectsPath = projectsPath;
		
			formattingNormal = new Formatting
			{
				FontFamily = new System.Drawing.FontFamily("Times New Roman"),
				Size = 14d,
				Bold = false
			};

			formattingBold = formattingNormal;
			formattingBold.Bold = true;

			codeDirFolders = GetCodeDirFolders(projectsPath);




			//string headerText = "Rejection Letter";
			//string letterBodyText = DateTime.Now.ToShortDateString();
			//string paraTwo = ""
			//	+ "Dear %APPLICANT%" + Environment.NewLine + Environment.NewLine
			//	+ "I am writing to thank you for your resume. Unfortunately, your skills and "
			//	+ "experience do not match our needs at the present time. We will keep your "
			//	+ "resume in our circular file for future reference. Don't call us, "
			//	+ "we'll call you. "

			//	+ Environment.NewLine + Environment.NewLine
			//	+ "Sincerely, "
			//	+ Environment.NewLine + Environment.NewLine
			//	+ "Jim Smith, Corporate Hiring Manager";

			//// Title Formatting:
			//var titleFormat = new Formatting();
			//titleFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
			//titleFormat.Size = 18D;
			//titleFormat.Position = 12;

			//// Body Formatting
			//var paraFormat = new Formatting();
			//paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
			//paraFormat.Size = 10D;
			//titleFormat.Position = 12;

			//// Create the document in memory:
			//var doc = DocX.Create(filePath);

			//// Insert each prargraph, with appropriate spacing and alignment:
			//Paragraph title = doc.InsertParagraph(headerText, false, titleFormat);
			//title.Alignment = Alignment.center;

			//doc.InsertParagraph(Environment.NewLine);
			//Paragraph letterBody = doc.InsertParagraph(letterBodyText, false, paraFormat);
			//letterBody.Alignment = Alignment.both;

			//doc.InsertParagraph(Environment.NewLine);
			//doc.InsertParagraph(paraTwo, false, paraFormat);

			//doc.Save();
			//Process.Start("WINWORD.EXE", filePath);

		}

		public void Create()
		{
			//document.ReplaceText(Environment.NewLine, "", false);	
		
			paragraphHeader = document.InsertParagraph(header + this.docNumber, false, formattingNormal);
			FormatToGost(paragraphHeader, Alignment.center);
			paragraphName = document.InsertParagraph(theme, false, formattingBold);
			FormatToGost(paragraphName, Alignment.center);
			paragraphTaskHeader = document.InsertParagraph(taskHeader + taskNumber, false, formattingNormal);
			FormatToGost(paragraphTaskHeader, Alignment.both);
			paragraphDivider = document.InsertParagraph("\r");
			FormatToGost(paragraphDivider, Alignment.both);
			paragraphCodeHeader = document.InsertParagraph(codeHeader, false, formattingNormal);
			FormatToGost(paragraphCodeHeader, Alignment.both);
			code = GetCode();
			foreach (string line in code)
			{
				paragraphCode = document.InsertParagraph(line, false, formattingNormal);
				FormatToGost(paragraphCode, Alignment.both);
			}
			document.InsertParagraph(paragraphDivider);
			paragraphResultHeader = document.InsertParagraph(resultHeader, false, formattingNormal);
			FormatToGost(paragraphResultHeader, Alignment.both);

			for (int i = 0; i < codeDirFolders.Length - 1; i++)
			{
				WriteTask();
			}
		
			try
			{
				document.SaveAs(filePath);
			}
			catch (Exception)
			{
				document.Dispose();
			}
		
			//Process.Start("WINWORD.EXE", filePath);
		}

		private string[] GetCodeDirFolders(string path)
		{
			return Directory.GetDirectories(path);
		}
	
		private void WriteTask()
		{
			taskNumber++;
			document.InsertParagraph(paragraphDivider);
			paragraphTaskHeader = document.InsertParagraph(taskHeader + taskNumber + ".", false, formattingNormal);
			FormatToGost(paragraphTaskHeader, Alignment.both);
			document.InsertParagraph(paragraphDivider);
			document.InsertParagraph(paragraphCodeHeader);
		
			code = GetCode();
			foreach (string line in code)
			{
				paragraphCode = document.InsertParagraph(line, false, formattingNormal); 
				FormatToGost(paragraphCode, Alignment.both);
			}
			
			document.InsertParagraph(paragraphDivider);
			document.InsertParagraph(paragraphResultHeader);
		}

		private string[] GetCode()
		{
			string[] code = new []{"ERROR"};
		
			foreach (string codeDirFolder in codeDirFolders)
			{
				string[] dirSplitted = codeDirFolder.Split('\\');
				string codeDir = codeDirFolder + '\\' + dirSplitted[dirSplitted.Length - 1];
			
				foreach (string file in Directory.GetFiles(codeDir))
				{
					if (file.Contains(".cs") && !file.Contains(".csproj"))
					{
						//code = System.IO.File.ReadAllText(file);
						//code = code.Replace("\r\n", "\r\r");
						code = File.ReadAllLines(file);
						
					}
				}
			}
		
			return code;
		}
	
		private void FormatToGost(Paragraph paragraph, Alignment alignment)
		{
			paragraph.Alignment = alignment;
			paragraph.SetLineSpacing(LineSpacingType.After, 0f);
			paragraph.SetLineSpacing(LineSpacingType.Line, 1.5f);
		}
	}
}

#region example

//string headerText = "Rejection Letter";
//string letterBodyText = DateTime.Now.ToShortDateString();
//string paraTwo = ""
//	+ "Dear %APPLICANT%" + Environment.NewLine + Environment.NewLine
//	+ "I am writing to thank you for your resume. Unfortunately, your skills and "
//	+ "experience do not match our needs at the present time. We will keep your "
//	+ "resume in our circular file for future reference. Don't call us, "
//	+ "we'll call you. "

//	+ Environment.NewLine + Environment.NewLine
//	+ "Sincerely, "
//	+ Environment.NewLine + Environment.NewLine
//	+ "Jim Smith, Corporate Hiring Manager";

//// Title Formatting:
//var titleFormat = new Formatting();
//titleFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
//titleFormat.Size = 18D;
//titleFormat.Position = 12;

//// Body Formatting
//var paraFormat = new Formatting();
//paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
//paraFormat.Size = 10D;
//titleFormat.Position = 12;

//// Create the document in memory:
//var doc = DocX.Create(filePath);

//// Insert each prargraph, with appropriate spacing and alignment:
//Paragraph title = doc.InsertParagraph(headerText, false, titleFormat);
//title.Alignment = Alignment.center;

//doc.InsertParagraph(Environment.NewLine);
//Paragraph letterBody = doc.InsertParagraph(letterBodyText, false, paraFormat);
//letterBody.Alignment = Alignment.both;

//doc.InsertParagraph(Environment.NewLine);
//doc.InsertParagraph(paraTwo, false, paraFormat);

//doc.Save();

#endregion