using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool radbtn1 = radioButton1.Checked;
            bool radbtn2 = radioButton2.Checked;

            if (radbtn1.ToString() == "True")
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string host = textBox1.Text;
                string port = textBox2.Text;
                if (host != "" && port != "")
                {
                    bool exc = false;
                    try
                    {
                        socket.Connect(host, int.Parse(port));
                    }
                    catch (SocketException)
                    {
                        exc = true;
                        Result.Items.Add("Port\t---\t" + port + "\t---\t[CLOSED]");
                    }
                    finally
                    {
                        if (!exc)
                        {
                            Result.Items.Add("Port\t---\t" + port + "\t---\t[OPEN]");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Поля не были заполнены");
                }
            }
            else if (radbtn2.ToString() == "True")
            {
                string host = textBox1.Text;
                int[] port = new int[] { 25565, 8621, 27015, 80, 7777, 27016, 8080, 443, 135, 445, 5040, 5357, 7680, 27060, 5357, 49664, 49665, 49666, 49667, 49668, 49669, 12025, 12110, 12119, 12143, 12465, 12563, 12995, 25752, 21, 22, 20, 8000, 9000, 3536 };
                if (host != "")
                {
                    foreach (int i in port)
                    {
                        bool exc = false;
                        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        try
                        {
                            socket.Connect(host, i);
                        }
                        catch (SocketException)
                        {
                            exc = true;
                            Result.Items.Add("Port\t---\t" + i + "\t---\t[CLOSED]");
                        }
                        finally
                        {
                            if (!exc)
                            {
                                Result.Items.Add("Port\t---\t" + i + "\t---\t[OPEN]");
                                socket.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Поле не заполнено");
                }
            }
            else
            {
                MessageBox.Show("Выберите метод или введите значения!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Result.Items.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Result.Items.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = true;
            }
        }
    }
}
