using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class GiaoDienController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        // btnPlay
        Button btnPlay = root.Q<Button>("btnPlay");
        Label tvTitle = root.Q<Label>("tvTitle");

        btnPlay.clicked += () =>
        {
            tvTitle.text = "Xin CHAO!!!!";
            tvTitle.style.display = DisplayStyle.None; // bien mat 
            tvTitle.style.display = DisplayStyle.Flex; // hien thi
            Debug.Log("AAAA - Clicked");
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
