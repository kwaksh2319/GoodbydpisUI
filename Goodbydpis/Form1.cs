using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Goodbydpis
{
    public partial class Form1 : Form
    {
      //  private bool bButtonExit =false ;
        private Process ExternalProcess ;
    
        private bool bExitCheck = false;
        public Form1() //생성자 
        {
            InitializeComponent();
            CreateStartButtons();
            CreateText();
            CreateExitButtons();
           


        }
        private void CreateText()
        {
            

        }
        private void CreateStartButtons()
        {
            Button startButton = new Button();// 버튼 


            startButton.DialogResult = DialogResult.OK;//dialog 
                                                       //  startButton.Name = "Start";
            startButton.Text = "Start"; //버튼 이름 


            Point pts = new Point(startButton.Size); //버튼 사이즈에 따른 위치값 
            pts.X = 350;
            pts.Y = 200;
            //int a = 350;

            startButton.Location = pts;
            startButton.Click += btnStart_Click;//함수 버튼 클릭
            Controls.Add(startButton); //컨트롤러에 버튼 추가 

            // Controls.

        }
        private void CreateExitButtons()
        {
            Button exitButton = new Button();// 버튼 


            exitButton.DialogResult = DialogResult.OK;//dialog 
                                                      //  startButton.Name = "Start";
            exitButton.Text = "Exit"; //버튼 이름 


            Point pts = new Point(exitButton.Size); //버튼 사이즈에 따른 위치값 
            pts.X = 350;
            pts.Y = 280;
            //int a = 350;

            exitButton.Location = pts;
            exitButton.Click += btnExit_Click;//함수 버튼 클릭
            Controls.Add(exitButton); //컨트롤러에 버튼 추가 

            // Controls.

        }


        private void Form1_Load(object sender, EventArgs e)
        {//메인 폼 update 구간 

            


        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하겠습니까?", "My Application",
          MessageBoxButtons.YesNo) == DialogResult.No)
            {

                // Cancel the Closing event from closing the form.
                e.Cancel = true;
                // Call method to save file...
            }
            if (bExitCheck == true)
            {
                MessageBox.Show("프로세스가 종료되었습니다.");
                ExternalProcess.Kill();

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
          
            
            if (bExitCheck==false)
            {
                MessageBox.Show("종료될 프로세스가 없습니다.");
                return;
            }
            MessageBox.Show("종료되었습니다.");
            bExitCheck = false;
            ExternalProcess.Kill();
           
          
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {

            if (bExitCheck == true)
            {
                MessageBox.Show(" 프로세스가 실행중입니다.");
                return;
            }
            ExternalProcess = new Process();
           
            bExitCheck = true;
            ExternalProcess.StartInfo.FileName = @"goodbyedpi-0.1.5\x86_64\goodbyedpi.exe";//@"C:\Users\USER\source\repos\Goodbydpis\Goodbydpis\bin\Debug\goodbyedpi-0.1.5\x86_64\goodbyedpi.exe";
            ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ExternalProcess.Start();
          



        }
    }
}
