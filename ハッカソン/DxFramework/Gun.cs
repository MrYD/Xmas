using DxFramework.DxFrameWork;
using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
    class Gun : Button
    {
        double reactioncount;
        Graphic[] rests = new Graphic[5];

        public Gun(int layer)
            : base(layer)
        {
            reactioncount = 0;
            rest = 5;

            for (int i = 0; i < rests.Length; i++)
            {
                rests[i] = new Graphic(1);
                rests[i].GraphName = "resource/img/bullet.png";
                rests[i].top = new Vector2(50+i*50,600);
            }
        }

        public override void update()
        {
            top = new Vector2(BasicInput.mouse.position.x + 30+reactioncount, 700+reactioncount);
            reactioncount /=1.3;

            for (int i = 0; i < rests.Length; i++)
            {
                if (i >= rest)
                    rests[i].isVisible = false;
                else
                    rests[i].isVisible = true;
            }

            base.update();
        }

        public void reaction()
        {
            reactioncount += 20;
        }

        public void action()
        {
            rest = 5;
        }

        public int rest { get; set; }
    }
}
