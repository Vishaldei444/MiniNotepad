using System;
using System.Windows.Forms;

namespace MiniNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            string text = txtEditor.Text;
            int words = text.Split(
                (char[]?)null,
                StringSplitOptions.RemoveEmptyEntries
            ).Length;

            int characters = text.Length;
            lblCount.Text = $"Words: {words} | Characters: {characters}";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtEditor.TextLength > 0 &&
    MessageBox.Show("Clear the current text?", "New Document",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            txtEditor.Clear();
            txtEditor.Focus();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open Text File";
                dialog.Filter = "Text files (*.txt)|*.txt";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                if (txtEditor.TextLength > 0 &&
                    MessageBox.Show("Replace the current text?", "Open File",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    txtEditor.Text = System.IO.File.ReadAllText(dialog.FileName);
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show("File open nahi hui.\n" + ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("File open nahi hui.\n" + ex.Message);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Text File";
                dialog.Filter = "Text files (*.txt)|*.txt";
                dialog.DefaultExt = "txt";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    System.IO.File.WriteAllText(dialog.FileName, txtEditor.Text);
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show("File save nahi hui.\n" + ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("File save nahi hui.\n" + ex.Message);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtEditor.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtEditor.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtEditor.Paste(DataFormats.GetFormat(DataFormats.UnicodeText));
        }
    }
}