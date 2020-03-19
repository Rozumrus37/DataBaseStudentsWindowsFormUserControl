using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;



namespace WindowsFormsApp1
{

	public partial class Form1 : Form
	{
		public DataTable StudentsMain = new DataTable();

		public Form1()
		{
			InitializeComponent(); 
		} 

		private void StudentsDataBaseLoad()
		{
			StudentsMain.Columns.Add("Name", typeof(string));
			StudentsMain.Columns.Add("Surname", typeof(string));
			StudentsMain.Columns.Add("Grade", typeof(int));
			StudentsMain.Columns.Add("Age", typeof(int));

			XmlReader students = XmlReader.Create("..\\..\\StudentsInfo.xml");
			while (students.Read())
			{
				if ((students.NodeType == XmlNodeType.Element) && (students.Name == "student"))
				{
					if (students.HasAttributes)
					{
						StudentsMain.Rows.Add(
							students.GetAttribute("name"),
							students.GetAttribute("surname"),
							students.GetAttribute("grade"),
							students.GetAttribute("age"));
					}
				}
			}
		
			dataGridView1.DataSource = StudentsMain;
			students.Close();
		}



		private void AddNewStudent()
		{
			List<Student> Studenty = new List<Student>();

			XmlSerializer Serializer = new XmlSerializer(typeof(List<Student>));

			foreach(DataRow row in StudentsMain.Rows)
			{
				Student StudentTemp = new Student();

				StudentTemp.name = row["name"].ToString();
				StudentTemp.surname = row["surname"].ToString();
				StudentTemp.grade = Int16.Parse(row["grade"].ToString());
				StudentTemp.age = Int16.Parse(row["age"].ToString());


				Studenty.Add(StudentTemp);
			}
			using (FileStream FileStudents = new FileStream("..\\..\\StudentsInfo.xml", FileMode.OpenOrCreate))
			{
				Serializer.Serialize(FileStudents, Studenty);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			StudentsDataBaseLoad();
		} 
		     
		private void button1_Click(object sender, EventArgs e)
		{
			AddNewStudent();
			MessageBox.Show("Students have been successfully added");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show(string.Format("State id = {0}, name = {1}", userControl11.SelectedState.ID, 
		    userControl11.SelectedState.Name));
		}
	}

	[Serializable]
	public class Student
	{

		public string name;
		public string surname;
		public int grade;
		public int age;
		public Student(){}

		public Student(string name, string surname, int grade, int age)
		{
			this.name = name;
			this.surname = surname;
			this.grade = grade;
			this.age = age;
		}
	}


}
