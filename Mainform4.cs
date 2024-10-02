/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 10/2/2024
 * Time: 1:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace simulatingParticles
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
	
		}
		void Button1Click(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			
		}
		
		public class particle
		{
			public int x;
			public int y;
			public int speed;
			public int xdir;
			public int ydir;
			public int alive = 1;
			public Panel panel0 = new Panel();
			public particle(int px ,int py, int pxd, int pyd)
			{
				this.x = px;
				this.y = py;
				this.xdir = pxd;
				this.ydir = pyd;
				
			}
			
		}
		
		public world w = new world();
		public int isfirsttime = 1;
		void Button2Click(object sender, EventArgs e)
		{
			if(isfirsttime==1){
				w.setMainForm(this);
				w.setGraphics(ref this.panel1);
				w.setFont(this);
				w.setNrOfControlInitialOnForm();
				isfirsttime=0;
			}
			w.addSampleParticles();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			w.clearScreen();
			w.moveParticles();
			w.drawParticlesSystem();
			
		}
		 
		public class board
		{
			public int x = 0;
			public int y = 0;
			public int w = 500;
			public int h = 350;
			public board()
			{
				;
			}
		}
		
		public class world
		{
			public Graphics g;
			public board draw = new board();
			public Font f;
			public Pen p = new Pen(Color.Black);
			public Brush b = new SolidBrush(Color.Black);
			public Random r = new Random();
			public MainForm mf;
			public int startingControlNrOnForm = 0;
			
			public void  setNrOfControlInitialOnForm()
			{
				startingControlNrOnForm = mf.Controls.Count;
			}
			
			public List<particle> listp = new List<particle>();
			public void addParticle(particle p)
			{
				listp.Add(p);
				mf.Controls.Add(p.panel0);
				int x = mf.Controls.Count-1;
				mf.Controls[x].Visible = true;
				mf.Controls[x].Left = p.x;
				mf.Controls[x].Top = p.y;
				mf.Controls[x].Width = 2;
				mf.Controls[x].Height = 2;
				mf.Controls[x].BackColor = Color.Red;
				
				
				
			}
			public void addSampleParticles()
			{
				for(int i = 0 ; i < 100 ;i++)
				{
					addParticle(new particle((int)r.Next(1,300),(int)r.Next(1,300),(int)r.Next(1,5),(int)r.Next(1,5)));
				}
			}
			public void setGraphics(ref Panel p)
			{
				g = p.CreateGraphics();
			}
			public void setMainForm(MainForm pmf)
			{
				this.mf = pmf;
			}
			public void setFont( MainForm m)
			{
				f = m.Font;
			}
			public void moveParticles()
			{
				for(int i = 0 ; i < listp.Count ;i++)
				{
					if(listp[i].alive==1){
						
					
					listp[i].x += listp[i].xdir;
					listp[i].y += listp[i].ydir;
					
					}
					
					if(listp[i].x > draw.w || listp[i].y > draw.h)
					{
						listp[i].alive=0;
					}
					if(listp[i].x < draw.x || listp[i].y < draw.y)
					{
						listp[i].alive=0;
					}
				}
			}
			
			public void changeDirectionOfAParticle(int i, int pdx, int pdy)
			{
				listp[i].xdir = pdx;
				listp[i].ydir = pdy;	
			}
			
			public void drawParticle(int i)
			{
				//g.DrawEllipse(p,listp[i].x,listp[i].y,2,2);
				//g.DrawLine(p,listp[i].x,listp[i].y,listp[i].x-1,listp[i].y+1);
				
				mf.Controls[i+startingControlNrOnForm].Left = listp[i].x;
				mf.Controls[i+startingControlNrOnForm].Top = listp[i].y;
			try{	}
				catch{};
			
			}
			public void drawParticlesSystem()
			{
				for(int i = 0 ; i < listp.Count ;i++)
				{
					if(listp[i].alive==1){
						drawParticle(i);
					}
				}
			}
			public void clearScreen()
			{
				g.Clear(Color.White);
			}
			
			
				
		}
		
		
		
	}
}
