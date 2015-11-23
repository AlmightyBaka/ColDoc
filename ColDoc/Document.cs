// CollegeDocs: Document.cs

using System.Diagnostics;
using Novacode;
using System;

namespace ColDoc
{
	public class Document
	{
		#region data
		private string filePath;
		private DocX document;

		private Formatting formattingNormal;
		private Formatting formattingBold;

		private string header = "Лабораторная работа №";
		private int docNumber;
		private string theme;
		private string task = "Задание №";
		private int taskNumber = 1;
		private string code = "Текст программы:";
		private string result = "Результат:";

		private Paragraph paragraphHeader;
		private Paragraph paragraphName;
		private Paragraph paragraphTask;
		private Paragraph paragraphCode;
		private Paragraph paragraphResult;
		private Paragraph paragraphDivider;

		#endregion

		public Document(string filePath, int docNumber, string theme)
		{
			//filePath = @"E:\Code\C#\ColDoc\Docs\test.docx";
			//document = DocX.Create(filePath);
			document = DocX.Load(@"E:\Code\C#\ColDoc\Docs\frame.docx");

			this.filePath = filePath;
			this.docNumber = docNumber;
			this.theme = theme;

			formattingNormal = new Formatting
			{
				FontFamily = new System.Drawing.FontFamily("Times New Roman"),
				Size = 14d,
				Bold = false
			};

			formattingBold = formattingNormal;
			formattingBold.Bold = true;
		}

		public void Create()
		{
			paragraphHeader = document.InsertParagraph(header + this.docNumber, false, formattingNormal);
			formatGOST(paragraphHeader, Alignment.center);
			paragraphName = document.InsertParagraph(theme, false, formattingBold);
			formatGOST(paragraphName, Alignment.center);
			paragraphTask = document.InsertParagraph(task + taskNumber, false, formattingNormal);
			formatGOST(paragraphTask, Alignment.both);
			paragraphDivider = document.InsertParagraph("\n\n");
			formatGOST(paragraphDivider, Alignment.both);
			paragraphCode = document.InsertParagraph(code, false, formattingNormal);
			formatGOST(paragraphCode, Alignment.both);
			document.InsertParagraph(paragraphDivider);
			paragraphResult = document.InsertParagraph(result, false, formattingNormal);
			formatGOST(paragraphResult, Alignment.both);

			for (int tasks = 0; tasks < 2; tasks++)
			{
				MakeTemplate();
			}
		
			try
			{
				document.SaveAs(filePath);
			}
			catch (Exception)
			{
				document.Dispose();
			}
			Process.Start("WINWORD.EXE", filePath);
		}
	
		private void MakeTemplate()
		{
			document.InsertParagraph(paragraphDivider);
			taskNumber++;
			paragraphTask = document.InsertParagraph(task + taskNumber + ".", false, formattingNormal);
			formatGOST(paragraphTask, Alignment.both);
			document.InsertParagraph(paragraphDivider);
			document.InsertParagraph(paragraphCode);
			document.InsertParagraph(paragraphDivider);
			document.InsertParagraph(paragraphResult);
		}

		private void formatGOST(Paragraph paragraph, Alignment alignment)
		{
			paragraph.Alignment = alignment;
			paragraph.IndentationBefore = 0;
			paragraph.IndentationAfter = 0;
			paragraph.IndentationFirstLine = 0;
			paragraph.IndentationHanging = 0;
			paragraph.SetLineSpacing(LineSpacingType.Line, 1.5f);
			paragraph.Spacing(0);
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