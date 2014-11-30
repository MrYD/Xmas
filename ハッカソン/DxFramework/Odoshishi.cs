using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
    class Odoshishi : Button
    {
        public Odoshishi() : base() 
        {
            deadcount = -1;
            deadFlag = false;
            this.top = new Vector2(DX.GetRand(1300)+100, DX.GetRand(500)+50);
            this.GraphName = "resource/img/オドシシ.png";
        }

        double deadcount;

        public override void update()
        {
            if (!isVisible) return;
            int frsf = deadcounter();
            if (frsf>1)
                this.GraphName = "resource/img/死んだオドシシ.png";
            if (frsf> 4)
                this.GraphName = "resource/img/もっと死んだオドシシ.png";
            if (frsf>10)
                this.isVisible = false;
            if (deadFlag) return;

            top += new Vector2(4,0);
            if (top.x<0&&top.x>1600)
            {
                isVisible = false;
            }

            base.update();
        }

        public void dead()
        {
            deadFlag = true;
            deadcount = 0;
        }

        public int deadcounter()
        {
            if (deadcount==-1)
                return 0;
            deadcount++;
            return (int)deadcount;
        }

        public bool deadFlag { get; set; }
    }
}
