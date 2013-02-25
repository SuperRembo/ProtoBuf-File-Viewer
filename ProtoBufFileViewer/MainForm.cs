using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ProtoBuf.Data;

namespace ProtobufFileViewer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			LoadFile(dlg.FileName);
		}

		public void LoadFile(string fileName)
		{
			Text = String.Format("ProtoBuf File Viewer - {0}", fileName);
			mainDataGridView.DataSource = ReadProtoBufFile(fileName);
		}

		private DataTable ReadProtoBufFile(string fileName)
		{
			try
			{
				using (var stream = File.OpenRead(fileName))
				using (var reader = DataSerializer.Deserialize(stream))
				{
					var table = new DataTable();
					table.Load(reader);
					return table;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Unable to load file {0}. {1}", fileName, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}
	}
}
