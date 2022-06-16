# Unity Render Streaming Note

## Unity Render Streaming

### Result
![](https://i.imgur.com/ju2TLbA.png)



repo:
https://github.com/shinn716/URS_HDRP_Prototype

### Version
1. Unity Editor 2021.3.4f1
2. Unity Render Streaming 3.1.0-exp.3
3. Input System 1.3

### Step
1. Unity Render Streaming 匯入 Project
Package Manager/Add package from git URL...  ```com.unity.renderstreaming@3.1.0-exp.3```
![](https://i.imgur.com/Xp3DDof.png)

2. 下載 WebServer app
![](https://i.imgur.com/NCWeCtp.png)

3. 開啟範例 
開啟 Unity Render Streaming/3.1.0-exp.3/RenderPipline/HDRP
![](https://i.imgur.com/rUh7jMh.png)

4. 確認 Signaling Type/URL
Signaling Type -> WebSocketSignaling
Signaling URL -> WS://localhost
![](https://i.imgur.com/Ks9vZjf.png)

5. 確認 Input System 版本
Input System 版本為1.3.0
![](https://i.imgur.com/Uge8JEg.png)

6. 切換 Input System
以下功能需調整
* Open Project Settings window, and **Player > Resolution and Presentatoin, and enable Run In Background**.
* Move Input System Package in Project Settings window, and set **Ignore Focus for Background Behavior**.
* In the Input System Package, set the Play Mode Input Behavior to **All Device Input Always Goes To Game View.**
![](https://i.imgur.com/yXWaFlz.png)

7. 新增 Player Input Action
Input Action
![](https://i.imgur.com/XlWIEUi.png)

8. Input Receiver
填入 Callback Context 參數
![](https://i.imgur.com/FQsPXyU.png)

自訂 InputAction
```
public class MyInputAction : MonoBehaviour
{
   ...
   
    public void OnClick(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValueAsButton();
        Debug.Log("OnClick: " + input);
    }
    public void OnPointerMove(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValue<Vector2>();
        Debug.Log("OnMouseMove: " + input);
    }

    public void OnRotationX(InputAction.CallbackContext Context)
    {
        rotx = Context.ReadValue<float>();
    }

    public void OnRotationY(InputAction.CallbackContext Context)
    {
        roty = Context.ReadValue<float>();
    }

    public void OnPressedWASD(InputAction.CallbackContext _context)
    {
        var input = _context.ReadValue<Vector2>();
        Debug.Log("OnPressedWASD: " + input);
    }
    ...
}
```

9. 在 Event System 設定為 Input System Module
![](https://i.imgur.com/DWL3ywk.png)

10. 開啟 WebServer
WebServer.exe -w 使用 WebSocketSingaling 模式 
![](https://i.imgur.com/IUe9OGJ.jpg)

11. 執行 Unity 
![](https://i.imgur.com/nkvLr0e.png)

13. 在瀏覽器輸入 IP (localhost)
![](https://i.imgur.com/4x2kHOl.png)
![](https://i.imgur.com/TBRxfhF.png)
![](https://i.imgur.com/MTZCKHh.png)



### Setting for TURN Server
若網路環境為 LAN, 可使用 Turn Server, 設定步驟參考官方.
**Turn Server**
https://docs.unity3d.com/Packages/com.unity.renderstreaming@3.1/manual/turnserver.html
![](https://docs.unity3d.com/Packages/com.unity.renderstreaming@3.1/manual/images/turn-renderstreaming-inspector.png)

**WebRTC samples Trickle ICE**
https://webrtc.github.io/samples/src/content/peerconnection/trickle-ice/
![](https://docs.unity3d.com/Packages/com.unity.renderstreaming@3.1/manual/images/turn-connection-testing.png)



---



## Input System 1.3
待整理

https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/manual/QuickStartGuide.html

![](https://i.imgur.com/yXWaFlz.png)


![](https://i.imgur.com/an8NXUG.png)


![](https://i.imgur.com/CVqYkoR.png)


![](https://i.imgur.com/aEuRYTV.png)
![](https://i.imgur.com/o1E5RMU.png)



## Reference
1. How to Enable UI with the New Input System
https://www.youtube.com/watch?v=TBcfhJoCVQo&feature=emb_title
{%youtube TBcfhJoCVQo %}

2. Input System 1.3
https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/manual/QuickStartGuide.html

3. Unity 新 InputSystem 的简要使用
https://zhuanlan.zhihu.com/p/106396562

4. [Unity] 新版 Input System 基礎用法教學 – WASD 移動物件（可斜走）
https://tedliou.com/archives/unity-input-system-movement-tutorial/

5. Unity Render Streaming
https://docs.unity3d.com/Packages/com.unity.renderstreaming@3.1/manual/index.html