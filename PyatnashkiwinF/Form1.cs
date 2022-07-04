using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using GlobalHotKey;

namespace PyatnashkiwinF
{
    public partial class Form1 : Form
    {
        HotKeyManager hotKeyManager;
        Pyatnashki _pyatnashki;
        Game15UI _game15;
        public Form1()
        {
            InitializeComponent();
            hotKeyManager = new HotKeyManager();
            HotKey hotKey = new HotKey();
            var HotKey = hotKeyManager.Register(Key.Z, System.Windows.Input.ModifierKeys.Control);
            hotKeyManager.KeyPressed += HotKeyManagerPressed; 
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pyatnashki = new Pyatnashki();
            _game15 = new Game15UI(pictureBox1, _pyatnashki);
            _game15.DrawArea();
        }
        private void HotKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.HotKey.Key == Key.Z)
            {
                _pyatnashki.Undo();
                _game15.DrawArea();
            }
               
        }
        private void menuStrip1_SizeChanged(object sender, EventArgs e)
        {
            if (_pyatnashki != null)
            {
                _game15 = new Game15UI(pictureBox1, _pyatnashki);
                _game15.DrawArea();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (_pyatnashki != null)
            {
                _pyatnashki.Save();
                int height = pictureBox1.Width > pictureBox1.Height ? pictureBox1.Height : pictureBox1.Width;
                height /= _pyatnashki.N;
                int x = e.X / height;
                int y = e.Y / height;
                if (_pyatnashki != null)
                {
                    _pyatnashki.Step(x, y);
                    _game15.DrawArea();
                    if (_pyatnashki.IsWinner())
                    {
                        MessageBox.Show("You Win");
                    }
                }
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _pyatnashki.Undo();
            _game15.DrawArea();
        }
    }
}
