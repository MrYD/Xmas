using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DxFramework
{
    class StartScene : Scene
    {

        public StartScene()
            : base()
        {
            instance = this;
        }
        public override void init()
        {
            Time = 0;
            var back = new Graphic();
            back.GraphName = "resource/img/startback.png";
            click = new Graphic();
            click.GraphName = "resource/img/click.png";
            click.top = new Vector2(400,550);
            var gamescene = new GameScene();
            var endscene = new EndScene();
            GameScene.instance.wholeInit();
        }
        public override void update()
        {
            Time++;
            if (BasicInput.mouse.left.down)
            {
                NextScene = GameScene.instance; 
            }
            if (Time % 50 == 0)
            {
                if (click.isVisible)
                {
                    click.isVisible = false;
                }
                else click.isVisible = true;
            }
        }
        public static StartScene instance { get; set; }

        public int Time { get; set; }

        public Graphic click { get; set; }
    }
}
