﻿using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
    class Rujura : Button
    {
        public Rujura(int layer) : base(layer) 
        {
            deadcount = -1;
            deadFlag = false;
            exRate = 1;
            this.top = new Vector2(DX.GetRand(1000)+20, DX.GetRand(500)+20);
            this.GraphName = "resource/img/ルージュラ.png";
            preSize = this.size;
        }

        double deadcount;
        private double exRate;
        private Vector2 preSize;
        private Vector2 postSize;

        public override void update()
        {
            if (!isVisible) return;
            this.exRate += 0.01*GameScene.instance.Time/500;
            int frsf = deadcounter();
            if (frsf>1)
                this.GraphName = "resource/img/死んだルージュラ.png";
            this.size = postSize*0.9;
                this.layer = -10;
            if (frsf> 4)
                this.GraphName = "resource/img/もっと死んだルージュラ.png";
            this.size = postSize*0.8;
            if (frsf > 10)
            { this.delete(); return; }
            if (deadFlag) return;
         
            this.size = preSize * exRate;
            this.postSize = this.size;
            this.layer = -10 + (int) exRate * 2;
            
            if (exRate >= 5)
            {
                EndScene.instance.wholeInit();
                GameScene.instance.NextScene = EndScene.instance;
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
        public override void draw()
        {
            if (!isVisible)
                return;
               DX.DrawExtendGraph( (int)top.x, (int)top.y, (int)bottom.x, (int)bottom.y,
　　　　　　　　　　 graphHandle , DX.TRUE ) ;
        }

        public bool deadFlag { get; set; }
        public bool GameEndFlage { get; set; }
    }
}
