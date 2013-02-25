using System;
using System.Windows.Forms;

namespace ProtobufFileViewer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var mainForm = new MainForm();
			if (args.Length >= 1)
				mainForm.LoadFile(args[0]);
			Application.Run(mainForm);
		}
	}
}
