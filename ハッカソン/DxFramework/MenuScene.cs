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
        public List<Button> Santa;
        public MenuScene()
            : base()
        {
            init();
            instance = this;
        }
        public override void init()
        {
            instance = this;
            Santa = new List<Button>();
            Santa.Add(new Button());
            count = 0;
            Time = 0;
            instance = this;
        }
        public override void update()
        {
            base.update();
            Time++;
            if (Time%50==0)
            {
                count++;
                Santa.Add(new Button());
                Santa[count].ComplexActionSender=count;
                Santa[count].mid = new Vector2(DX.GetRand(1600),DX.GetRand(900));
                Santa[count].ClickedComplexAction = (object sender) =>
                {
                    Santa[(int)sender].isVisible = false;
                };
                Santa[count].GraphName = "resource/img/ルージュラ.png";
            }
        }
        public int Time { get; set; }
    }
}
    

