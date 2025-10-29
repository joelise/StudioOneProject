using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CodeInputTest : MonoBehaviour
{
    public TMP_InputField InputField;
    public CodeUnlock codeUnlockScript;
    
    //public Button SubmitButton;
    

    void Start()
    {
        gameObject.SetActive(false);
        //SubmitButton.onClick.AddListener(SubmitCode);
    }
    public void SubmitCode()
    {
        string playerCode = InputField.text;
        codeUnlockScript.EnterCode(playerCode);
    }
}
