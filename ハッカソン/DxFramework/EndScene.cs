using DxFramework.DxFrameWork;
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

        public EndScene()
            : base()
        {
            init();
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
           
        }
        public override void update()
        {
            base.update();
        }
        public static EndScene instance { get; set; }
    }
}
