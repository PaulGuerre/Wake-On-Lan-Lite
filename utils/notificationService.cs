using Microsoft.Toolkit.Uwp.Notifications;

namespace Wake_On_Lan_Lite
{

    //Class that send a toast notification with the device name
    class notificationService
    {

        //Function that send the notification
        public void sendNotification(string deviceName)
        {
            new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813)
            .AddText("Device awake !")
            .AddText(deviceName + " has been succesfully awakened !")
            .Show();
        }
    }
}
