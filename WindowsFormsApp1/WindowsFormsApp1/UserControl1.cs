using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
         
        }

        public StateStudents SelectedState
        {
            get
            {
                return (StateStudents)comboBox2.SelectedItem;
            }
        }
       
        private void UserControl1_Load_1(object sender, EventArgs e)
        {
            List<StateStudents> list = new List<StateStudents>();
            list.Add(new StateStudents() { ID = 1, Name = "Ruslan" });
            list.Add(new StateStudents() { ID = 2, Name = "Ruslan2" });
            list.Add(new StateStudents() { ID = 3, Name = "Ruslan3" });
            list.Add(new StateStudents() { ID = 4, Name = "Ruslan4" });
            list.Add(new StateStudents() { ID = 5, Name = "Ruslan5" });
            comboBox2.DataSource = list;
            comboBox2.ValueMember = "ID";
            comboBox2.DisplayMember = "Name";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
