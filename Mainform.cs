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
			
			public particle(int px ,int py, int pxd, int pyd)
			{
				this.x = px;
				this.y = py;
				this.xdir = pxd;
				this.ydir = pyd;
			}
		}
		
		public world w = new world();
		
		void Button2Click(object sender, EventArgs e)
		{
			w.setGraphics(ref this.panel1);
			w.setFont(this);
			w.addSampleParticles();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			w.clearScreen();
			w.moveParticles();
			w.drawParticlesSystem();
			
		}
		 
		
		public class world
		{
			public Graphics g;
			public Font f;
			public Pen p = new Pen(Color.Black);
			public Brush b = new SolidBrush(Color.Black);
			public Random r = new Random();
			
			public List<particle> listp = new List<particle>();
			public void addParticle(particle p)
			{
				listp.Add(p);
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
			public void setFont( MainForm m)
			{
				f = m.Font;
			}
			public void moveParticles()
			{
				for(int i = 0 ; i < listp.Count ;i++)
				{
					listp[i].x += listp[i].xdir;
					listp[i].y += listp[i].ydir;
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
				g.DrawLine(p,listp[i].x,listp[i].y,listp[i].x-1,listp[i].y+1);
			
			}
			public void drawParticlesSystem()
			{
				for(int i = 0 ; i < listp.Count ;i++)
				{
					drawParticle(i);
				}
			}
			public void clearScreen()
			{
				g.Clear(Color.White);
			}
			
			
				
		}
		
		
		
	}
}
