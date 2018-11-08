using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeedGame.Data;

namespace SpeedGame.Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        //버튼에 랜덤 숫자 값 넣기
        public void InsertNum(bool triger) 
        {
            var list = RDControl.Random_Load(triger);            

            for (int i = 1; i <= 9; i++)
            {
                var button = this.Controls.Find("button" + i, true);
                button[0].Text = list[i-1].ToString();
            }            
        }

        // 삭제하기 로직
        private void Delete(Button button) 
        {
            
            if (int.Parse(button.Text) == BSControl.getInstance().N)
            {
                button.Text = "";
                BSControl.getInstance().N++;
            }

            if (BSControl.getInstance().N == 10 && 
                BSControl.getInstance().Level == 1)
            {
                InsertNum(true);
                BSControl.getInstance().Level = 2;
            }
            else if (BSControl.getInstance().N == 19)
            {
                timer1.Stop();
                MessageBox.Show(
                    $"기록 시간 : {BSControl.getInstance().Time:N1} \n너 쫌 한다?");                
            }
        }

        // 클릭시 발생 이벤트
        void OnClick(object sender, EventArgs e) 
        {
            Button button = sender as Button;
            try
            {
                Delete(button);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.Click += OnClick;
            }

            InsertNum(false);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BSControl.getInstance().Time += 0.1f;
            count.Text = $"{BSControl.getInstance().Time:N1}";
        }
    }
}
