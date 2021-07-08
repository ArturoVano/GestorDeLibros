using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaFinal
{
    public partial class Eliminar : Form
    {

        public int id_eliminar { get; set; }

        public Eliminar()
        {
            InitializeComponent();
        }

        public void setData(int id, string tit)
        {
            string[] filaNueva = new string[2];
            filaNueva[0] = id.ToString();
            filaNueva[1] = tit;
            dataGridView1.Rows.Add(filaNueva);
        }

        private void delBtn_Click(object sender, EventArgs e)
        {

            //  m.eliminaLibro(libro_id);
            int num = dataGridView1.SelectedRows.Count;

            if (dataGridView1.SelectedRows.Count == 1) {
                //Cojo la fila seleccionada, el valor que tiene en la primera columna y le digo al modelo que la elimine de la BD:
                foreach (DataGridViewRow row in dataGridView1.SelectedRows) {

                   string firstCol = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
                    
                   try {

                        id_eliminar = Int32.Parse(firstCol);
                        dataGridView1.Rows.RemoveAt(row.Index);
                        
                        DialogResult = DialogResult.OK;
                    }
                    catch (FormatException ) {

                        MessageBox.Show("Error al procesar los datos de la fila seleccionada");
                    }
                }
            }
        }

        
    }
}
