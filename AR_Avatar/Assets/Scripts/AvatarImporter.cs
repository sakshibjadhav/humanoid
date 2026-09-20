using UnityEngine;
using UnityEngine.Events;
using ReadyPlayerMe.AvatarLoader;
using ReadyPlayerMe.Core;

public class AvatarImporter : MonoBehaviour
{
    public string avatarUrl = "https://models.readyplayer.me/6401eeb05167081fc2eb000d.glb";

    public GameObject avatar;

    public void Start()
    {
        ApplicationData.Log();
            var avatarLoader = new AvatarObjectLoader();
            // use the OnCompleted event to set the avatar and setup animator
            avatarLoader.OnCompleted += (_, args) =>
            {
                avatar = args.Avatar;
                AvatarAnimatorHelper.SetupAnimator(args.Metadata.BodyType, avatar);
            };
            avatarLoader.LoadAvatar(avatarUrl);
    }
}