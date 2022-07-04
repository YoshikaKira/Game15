using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PyatnashkiwinF
{
    class Game15UI
    {
        PictureBox _pictureBox;
        Pyatnashki _pyatnashki;
        Graphics _graphics;
        public Game15UI(PictureBox pictureBox, Pyatnashki pyatnashki)
        {
            _pictureBox = pictureBox;
            _pyatnashki = pyatnashki;
            _graphics = pictureBox.CreateGraphics();
        }
        public void DrawArea()
        {
            
            int height = _pictureBox.Width > _pictureBox.Height ? _pictureBox.Height : _pictureBox.Width;
            height /= _pyatnashki.N;
            height -= 1;
            for (int i = 0; i < _pyatnashki.N; i++)
                for (int j = 0; j < _pyatnashki.N; j++)
                {
                    if (_pyatnashki.Area[i, j] != 0)
                    {
                        _graphics.DrawImage(Image.FromFile("C:\\Users\\STUDENT\\Desktop\\kvadrat.png"), j * height, i * height, height, height);
                        _graphics.DrawString(_pyatnashki.Area[i, j].ToString(), new Font("Calibri", height / 2), new SolidBrush(Color.Chocolate), j * height + 5, i * height + 5);
                    }
                    else
                    {
                        _graphics.FillRectangle(new SolidBrush(Color.White), j * height, i * height, height, height);
                    }
                }
        }
    }
}
