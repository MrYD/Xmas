using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
    class Rujura : Button
    {
        public Rujura(int Rayer) : base(Rayer) 
        {
            deadcount = -1;
            deadFlag = false;
        }

        double deadcount;

        public override void update()
        {
            if (!isVisible) return;
            int frsf = deadcounter();
            if (frsf>1)
                this.GraphName = "resource/img/死んだルージュラ.png";
            if (frsf> 4)
                this.GraphName = "resource/img/もっと死んだルージュラ.png";
            if (frsf>10)
                this.isVisible = false;
            if (deadFlag) return;
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
