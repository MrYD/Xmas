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
        public int bgm;
        private Button scope;

        public GameScene(): base()
        {
            instance = this;
        }
        public override void init()
        {
            score = 0;
            Santa = new List<Rujura>();
            Tonakai = new List<Odoshishi>();
            rcount = 0;
            ocount = 0;
            Time = 0;
            var back = new Graphic(-11);
            back.GraphName = "resource/img/back.png";
            gun = new Gun(1);
            gun.GraphName = "resource/img/gun.png";
            var text = new Text(2);
            text.FontHandle = DX.CreateFontToHandle(null, 70, -1);
            text.top = new Vector2(1200, 700);
            text.color = DX.GetColor(240, 240, 240);
            text.updateAction = () => { text.text = "Score:" + score; };
            bgm = DX.LoadSoundMem("resource/se/bgm.mp3");

            scope = new Button();
            scope.GraphName = "resource/img/スコープ.png";
            scope.mid = BasicInput.mouse.position;
            DX.PlaySoundMem(bgm, DX.DX_PLAYTYPE_LOOP);
        }
        public override void update()
        {
            Time++;

            scope.mid = BasicInput.mouse.position;

            int a = 100 - Time / 50;
            if (a <= 50)
            {
                a = 50;
            }
            if (DX.GetRand(a) == 0)
            {
                Santa.Add(new Rujura(-10));
                Santa[rcount].ComplexActionSender = rcount;
                Santa[rcount].ClickedComplexAction = (object sender) =>
                {
                    if (gun.rest <= 0) { }
                    else
                    {
                        Santa[(int)sender].dead();
                        score++;
                    }
                };
                rcount++;
            }
            if (Time % 400 == 0)
            {
                Tonakai.Add(new Odoshishi(-10));
                Tonakai[ocount].ComplexActionSender = ocount;
                Tonakai[ocount].ClickedComplexAction = (object sender) =>
                {
                    if (gun.rest <= 0) { }
                    else
                    {
                        Tonakai[(int)sender].dead();
                        score--;
                    }
                };
                ocount++;
            }
            if (BasicInput.mouse.left.up)
            {
                gun.rest--;
                gun.reaction();
                DX.PlaySoundFile("resource/se/gun.mp3",DX.DX_PLAYTYPE_BACK);
            }
            if (BasicInput.mouse.right.up)
            {
                gun.action();
            }
        }
        public int Time { get; set; }
    }
}
    

