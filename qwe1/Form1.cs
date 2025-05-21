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
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shippersBindingSource.DataSource = db.Shippers.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 frm = new Form2();
                frm.ship = null;
                DialogResult dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    shippersBindingSource.DataSource = null;
                    shippersBindingSource.DataSource = db.Shippers.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shippers ship = (Shippers)shippersBindingSource.Current;
            Form2 frm = new Form2();
            frm.ship = ship;
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                shippersBindingSource.DataSource = null;
                shippersBindingSource.DataSource = db.Shippers.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Shippers ship = (Shippers)shippersBindingSource.Current;
            DialogResult dr = MessageBox.Show("Удалить запись" + ship.ShipperID + "?", "Удаление записи");
            if (dr == DialogResult.OK)
            {
                db.Shippers.Remove(ship);
                try
                {
                    db.SaveChanges();
                    shippersBindingSource.DataSource = db.Shippers.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.InnerException.Message);
                }
            }
        }
    }
}
