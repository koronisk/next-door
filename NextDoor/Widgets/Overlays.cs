using NextDoor.Graphics;
using SFML.Graphics;

namespace NextDoor.Widgets
{
    // я очень хотел сделать это в yaml, но потерпел большие неудачи в виде IL2057: Unrecognized value passed to the parameter 'typeName' of method 'System.Type.GetType(String, Boolean)'

    public class Overlay
    {
        public virtual void Load()
        {
            foreach (var widget in new Dictionary<string, Widget>(Widget.Widgets))
            {
                Widget.Widgets[widget.Key] = null!;
                GC.Collect();
            }
            Widget.Widgets.Clear();
        }
    }

    public class MenuOverlay : Overlay
    {
        public override void Load()
        {
            base.Load();
            Audio.SetBackgroundMusic("./Assets/Audio/Music/VanSteppin.mp3", 64);
            Widget.Widgets.Add("MainMenuController", new MainMenuWidget(new WidgetInfo("Controller", "false", "false")));
        }
    }
}