﻿using DxFramework.DxFrameWork;
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
        public int score;

        public int count;
        public static MenuScene instance { get; private set; }
        public List<Rujura> Santa;
        public MenuScene()
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
            count = 0;
            Time = 0;
            instance = this;
            var back = new Graphic(-1);
            back.GraphName = "resource/img/back.png";
            var gun = new Graphic(1);
            gun.GraphName = "resource/img/guns.png";

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
            if (Time%50==0)
            {
                Santa.Add(new Rujura(0));
                Santa[count].ComplexActionSender=count;
                Santa[count].ClickedComplexAction = (object sender) =>
                {
                    Santa[(int)sender].dead();
                    score++;
                };
                count++;
            }
        }
        public int Time { get; set; }
    }
}
    

