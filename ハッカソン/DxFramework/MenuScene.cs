using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
    class MenuScene : Scene
    {
        public int count;
        public static MenuScene instance { get; private set; }
        public List<Rujura> Santa;
        public MenuScene()
            : base()
        {
            init();
            instance = this;
        }
        public override void init()
        {
            instance = this;
            Santa = new List<Rujura>();
            Santa.Add(new Rujura(0));
            count = 0;
            Time = 0;
            instance = this;
            var back = new Graphic(-1);
            back.GraphName = "resource/img/back.png";
            var gun = new Graphic(1);
            gun.GraphName = "resource/img/guns.png";
        }
        public override void update()
        {
            base.update();
            Time++;
            if (Time%50==0)
            {
                count++;
                Santa.Add(new Rujura(0));
                Santa[count].ComplexActionSender=count;
                Santa[count].mid = new Vector2(DX.GetRand(1600),DX.GetRand(900));
                Santa[count].ClickedComplexAction = (object sender) =>
                {
                    Santa[(int)sender].dead();
                };
                Santa[count].GraphName = "resource/img/ルージュラ.png";
            }
        }
        public int Time { get; set; }
    }
}
    

