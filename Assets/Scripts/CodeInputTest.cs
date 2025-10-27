using UnityEngine;
using TMPro;

public class CodeInputTest : MonoBehaviour
{
    public TMP_InputField InputField;
    public CodeUnlock codeUnlockScript;

    public void SubmitCode()
    {
        string playerCode = InputField.text;
        codeUnlockScript.EnterCode(playerCode);
    }
}
