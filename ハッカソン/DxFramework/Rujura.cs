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
        }

        double deadcount;

        public override void update()
        {
            if (deadcounter()>1)
                this.GraphName = "resource/img/死んだルージュラ";
            if (deadcounter() > 4)
                this.GraphName = "resource/img/もっと死んだルージュラ";
            if (deadcounter()>10)
                this.isVisible = false;
            base.update();
        }

        public void dead()
        {
            deadcount = 0;
        }

        public int deadcounter()
        {
            if (deadcount==-1)
                return 0;
            deadcount++;
            return (int)deadcount;
        }
    }
}
