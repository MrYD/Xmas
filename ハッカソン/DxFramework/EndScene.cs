using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DxFramework
{
    class EndScene : Scene
    {
        private Graphic back;
        private Text text;
        private bool flag;

        public EndScene(): base()
        {
            instance = this;
        }
        public override void init()
        {
            back = new Graphic();
            back.GraphName = "resource/img/GameEnd.png";
            text = new Text(1);
            text.FontHandle = DX.CreateFontToHandle(null, 70, -1);
            text.top = new Vector2(1200, 700);
            text.color = DX.GetColor(240, 240, 240);
            text.updateAction = () => { text.text = "Score:" + GameScene.instance.score; };
            flag = true;
        }
        public override void update()
        {
            if(flag) {
            DX.StopSoundMem(GameScene.instance.bgm);
            DX.PlaySoundFile("resource/se/kiss.mp3", DX.DX_PLAYTYPE_NORMAL);
            flag = false;
        }
           if (BasicInput.mouse.left.down)
           {
               StartScene.instance.wholeInit();
               NextScene = StartScene.instance;
           }
        }

        public static EndScene instance { get; private set;}
    }
}
