using System;
using System.Data;
using System.Windows.Forms;

namespace NoteTaker
{
    public partial class Notepad : Form
    {
        private DataTable dataTable;
        public Notepad()
        {
            InitializeComponent();
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Title", typeof(String));
            dataTable.Columns.Add("Messages", typeof(String));

            dataGrid.DataSource = dataTable;

            dataGrid.Columns["Messages"].Visible = false;
            dataGrid.Columns["Title"].Width = 240;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            titleTextBox.Clear();
            messageTextBox.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Add(titleTextBox.Text, messageTextBox.Text);

            titleTextBox.Clear();
            messageTextBox.Clear();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            if (dataGrid.CurrentCell == null)
                return;

            int index = dataGrid.CurrentCell.RowIndex;

            if (index < 0)
                return;
            titleTextBox.Text = dataTable.Rows[index].ItemArray[0].ToString();
            messageTextBox.Text = dataTable.Rows[index].ItemArray[1].ToString();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGrid.CurrentCell == null)
                return;

            int index = dataGrid.CurrentCell.RowIndex;

            dataTable.Rows[index].Delete();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
