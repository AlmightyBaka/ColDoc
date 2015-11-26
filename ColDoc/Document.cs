// CollegeDocs: Document.cs

using Novacode;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;

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
		private Paragraph paragraphEmptyLine;

		private string header = "Лабораторная работа №";
		private string taskHeader = "Задание №";
		private string codeHeader = "Текст программы:";
		private string resultHeader = "Результат:";
		private string theme;
		private string[] codeDirFolders;
		private int docNumber;
		private int taskNumber = 1;
	
		private Collection<string[]> code;
		private Bitmap screenshot;
		private bool makeScreenshot;

		#endregion

		public Document(string projectsPath, string filePath, int docNumber, string theme, bool makeScreenshot)
		{
			document = DocX.Load(@"E:\Code\C#\ColDoc\Docs\frame.docx");

			this.filePath = filePath;
			this.docNumber = docNumber;
			this.theme = theme;
			this.projectsPath = projectsPath;
			this.makeScreenshot = makeScreenshot;

			formattingNormal = new Formatting
			{
				FontFamily = new System.Drawing.FontFamily("Times New Roman"),
				Size = 14d,
				Bold = false
			};

			formattingBold = formattingNormal;
			formattingBold.Bold = true;

			codeDirFolders = Directory.GetDirectories(this.projectsPath);
		}

		public void Create()
		{
			paragraphHeader = document.InsertParagraph(header + this.docNumber, false, formattingNormal);
			FormatToGost(paragraphHeader, Alignment.center);
			paragraphName = document.InsertParagraph(theme, false, formattingBold);
			FormatToGost(paragraphName, Alignment.center);
			paragraphTaskHeader = document.InsertParagraph(taskHeader + taskNumber, false, formattingNormal);
			FormatToGost(paragraphTaskHeader, Alignment.both);
			paragraphEmptyLine = document.InsertParagraph("\r", false, formattingNormal);
			FormatToGost(paragraphEmptyLine, Alignment.both);
			document.InsertParagraph(paragraphEmptyLine);
			paragraphCodeHeader = document.InsertParagraph(codeHeader, false, formattingNormal);
			FormatToGost(paragraphCodeHeader, Alignment.both);
			InsertCode(0);
			paragraphResultHeader = document.InsertParagraph(resultHeader, false, formattingNormal);
			FormatToGost(paragraphResultHeader, Alignment.both);
			
			document.InsertParagraph(paragraphEmptyLine);

			for (int i = 1; i < codeDirFolders.Length; i++)
			{
				InsertTask(i);
			}

			try
			{
				document.SaveAs(filePath);
			}
			catch (Exception)
			{
				document.Dispose();
			}
		}

		private void InsertTask(int task)
		{
			taskNumber++;
			document.InsertParagraph(paragraphEmptyLine);
			document.InsertParagraph(paragraphEmptyLine);
			paragraphTaskHeader = document.InsertParagraph(taskHeader + taskNumber + ".", false, formattingNormal);
			FormatToGost(paragraphTaskHeader, Alignment.both);
			document.InsertParagraph(paragraphEmptyLine);
			document.InsertParagraph(paragraphEmptyLine);
			document.InsertParagraph(paragraphCodeHeader);

			InsertCode(task);

			document.InsertParagraph(paragraphResultHeader);
			document.InsertParagraph(paragraphEmptyLine);
		}

		private void InsertCode(int task)
		{
			code = GetCode(task);

			for (int file = 0; file < code.Count; file++)
			{
				paragraphCode = document.InsertParagraph(code[file][0], false, formattingNormal);
				FormatToGost(paragraphCode, Alignment.both);
				document.InsertParagraph(paragraphEmptyLine);
				file++;

				foreach (string line in code[file])
				{
					paragraphCode = document.InsertParagraph(line, false, formattingNormal);
					FormatToGost(paragraphCode, Alignment.both);
				}

				document.InsertParagraph(paragraphEmptyLine);
			}
		}

		private Collection<string[]> GetCode(int projectNumber)
		{
			Collection<string[]> code = new Collection<string[]>();
			string[] dirSplitted = codeDirFolders[projectNumber].Split('\\');
			//string codeDir = codeDirFolders[projectNumber] + '\\' + dirSplitted[dirSplitted.Length - 1];
			string projectDir = codeDirFolders[projectNumber];
			string[] folder = Directory.GetFiles(projectDir);
			int slnCount = -1;

			for (int i = 0; i < folder.Length; i++)
			{
				if (folder[i].Contains(".sln"))
				{
					slnCount = i; // TODO: check condition
					break;
				}
			}
		
			string codeDir = folder[slnCount].Remove(folder[slnCount].Length - 4);
			string[] projectSplitted = codeDir.Split('\\');
			codeDir = projectSplitted[projectSplitted.Length - 1];
			codeDir = projectDir + @"\\" + codeDir;

			foreach (string file in Directory.GetFiles(codeDir))
			{
				if (file.Contains(".cs") && !file.Contains(".csproj"))
				{
					string[] dir = file.Split('\\');
					code.Add(new[] { $@"\\ {dirSplitted[dirSplitted.Length - 1]}: {dir[dir.Length - 1]}" });
					code.Add(File.ReadAllLines(file));
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