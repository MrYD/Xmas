using DxFramework.DxFrameWork;
using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
    class GameScene : Scene
    {
        public int score;

        public int rcount;
        public int ocount;
        public static GameScene instance { get; private set; }
        public List<Rujura> Santa;
        public List<Odoshishi> Tonakai;
        public Gun gun;
        public GameScene()
            : base()
        {
            init();
            instance = this;
            score = 0;
        }

        public override void init()
        {
            instance = this;
            Santa = new List<Rujura>();
            Tonakai = new List<Odoshishi>();
            rcount = 0;
            ocount= 0;
            Time = 0;
            instance = this;
            var back = new Graphic(-20);
            back.GraphName = "resource/img/back.png";
            gun = new Gun(1);
            gun.GraphName = "resource/img/gun.png";

            var text = new Text(2);
            text.FontHandle = DX.CreateFontToHandle(null,70,-1);
            text.top = new Vector2(1200,700);
            text.color = DX.GetColor(240,240,240);
            text.updateAction = () => { text.text = "Score:" + score; };
        }
        public override void update()
        {
            base.update();
            Time++;
            if (DX.GetRand(100-Time/50)==0)
            {
                Santa.Add(new Rujura());
                Santa[rcount].ComplexActionSender=rcount;
                Santa[rcount].ClickedComplexAction = (object sender) =>
                {
                    if (gun.rest <= 0) { }
                    else
                    {
                        Santa[(int)sender].dead();
                        gun.reaction();
                        gun.rest -= 1;
                        score++;
                    }
                };
                rcount++;
            }
            if (Time % 400 == 0)
            {
                Tonakai.Add(new Odoshishi());
                Tonakai[ocount].ComplexActionSender = ocount;
                Tonakai[ocount].ClickedComplexAction = (object sender) =>
                {
                    if (gun.rest <= 0) { }
                    else
                    {
                        Tonakai[(int)sender].dead();
                        gun.reaction();
                        gun.rest -= 1;
                        score--;
                    }
                };
                ocount++;
            }

            if (BasicInput.mouse.right.up)
            {
                gun.action();
            }

        }
        public int Time { get; set; }
    }
}
    

