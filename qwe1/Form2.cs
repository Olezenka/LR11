using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qwe1
{
    public partial class Form2 : Form
    {
        Model1 db = new Model1();
        public Shippers ship { get; set; } = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ship == null)
            {
                ship = (Shippers)shippersBindingSource.List[0];
                db.Shippers.Add(ship);
            }
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (ship == null)
            {
                shippersBindingSource.AddNew();
                this.Text = " Добавление новой учетной записи";
            }
            else
            {
                shippersBindingSource.Add(ship);
                shipperIDTextBox.ReadOnly = true;
                this.Text = " Корректировка учетной записи " + ship.ShipperID;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
