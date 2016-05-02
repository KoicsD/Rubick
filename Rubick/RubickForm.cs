using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubick
{
    public partial class RubickForm : Form
    {
        public RubickForm()
        {
            InitializeComponent();
        }

        private IEnumerable<Button> GetFrontButtons()
        {
            yield return btnQ;
            yield return btnW;
            yield return btnE;
            yield return btnA;
            yield return btnS;
            yield return btnD;
            yield return btnZ;
            yield return btnX;
            yield return btnC;
        }

        private IEnumerable<Button> GetTopButtons()
        {
            yield return btnR;
            yield return btnT;
            yield return btnY;
            yield return btnF;
            yield return btnG;
            yield return btnH;
            yield return btnV;
            yield return btnB;
            yield return btnN;
        }

        private IEnumerable<Button> GetSideButtons()
        {
            yield return btnU;
            yield return btnI;
            yield return btnO;
            yield return btnJ;
            yield return btnK;
            yield return btnL;
            yield return btnM;
            yield return btnComma;
            yield return btnDot;
        }

        private void RubickForm_Load(object sender, EventArgs e)
        {
            foreach (Button btn in GetFrontButtons())
            {
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.FromArgb(btn.BackColor.A, 255 - btn.BackColor.R, 255 - btn.BackColor.G, 255 - btn.BackColor.B);
            }
            foreach (Button btn in GetTopButtons())
            {
                btn.BackColor = Color.Blue;
                btn.ForeColor = Color.FromArgb(btn.BackColor.A, 255 - btn.BackColor.R, 255 - btn.BackColor.G, 255 - btn.BackColor.B);
            }
            foreach (Button btn in GetSideButtons())
            {
                btn.BackColor = Color.Green;
                btn.ForeColor = Color.FromArgb(btn.BackColor.A, 255 - btn.BackColor.R, 255 - btn.BackColor.G, 255 - btn.BackColor.B);
            }
        }
    }
}
