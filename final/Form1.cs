using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace final
{
    public partial class Form1 : Form
    {

        public int m_iWidth;
        public int m_iHeight;
        public int m_iNoOfRows;
        public int m_iNoOfCols;
        public int m_iXOffset;
        public int m_iYOffset;
        public int m_iCount = 3;
        public int m_iGridMaxSize = 3;

        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NO_ROWS = 3;
        public const int DEFAULT_NO_COLS = 3;
        public const int DEFAULT_WIDTH = 60;
        public const int DEFAULT_HEIGHT = 60;


        public Form1()
        {
            Initialize();
            InitializeComponent();
            bThreadStatus = false;
        }

        private void OnPaint(object sender, EventArgs e)
        {
            DrawGrid();
        }

        public void Initialize()
        {

            m_iNoOfRows = DEFAULT_NO_ROWS;
            m_iNoOfCols = DEFAULT_NO_COLS;
            m_iWidth = DEFAULT_WIDTH;
            m_iHeight = DEFAULT_HEIGHT;
            m_iXOffset = DEFAULT_X_OFFSET;
            m_iYOffset = DEFAULT_Y_OFFSET;

        }

        private void DrawGrid()
        {
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.Red);
            layoutPen.Width = 5;


            int X = DEFAULT_X_OFFSET;
            int Y = DEFAULT_Y_OFFSET;

            for (int i = 0; i <= m_iCount; i++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X + this.m_iWidth * this.m_iCount, Y);
                Y = Y + this.m_iHeight;
            }

            X = DEFAULT_X_OFFSET;
            Y = DEFAULT_Y_OFFSET;
            for (int j = 0; j <= m_iCount; j++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_iHeight * this.m_iCount);
                X = X + this.m_iWidth;

            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 4;
            this.Refresh();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 6;
            this.Refresh();
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 5;
            this.Refresh();
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 7;
            this.Refresh();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread = new Thread(new ThreadStart(ThreadCounter));
            CounterThread.Start();
            bThreadStatus = true;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread.Suspend();
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread.Resume();

        }
        public void ThreadCounter()
        {
            try
            {
                while (true)
                {
                    m_iCount++;
                    if (m_iCount > m_iGridMaxSize)
                    {
                        m_iCount = 3;
                    }
                    Invalidate();
                    Thread.Sleep(500);


                }

            }
            catch (Exception ex)
            {

            }
        }

       
      

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CounterThread = new Thread(new ThreadStart(ThreadCounter));
            CounterThread.Start();
            bThreadStatus = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CounterThread.Suspend();
        }
    }
}