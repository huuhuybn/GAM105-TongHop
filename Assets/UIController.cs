using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    private Label tvTitle;
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        // btnPlay là tên của button đặt bên UI Builder, phân biệt hoa thường 
        Button btnPlay = root.Q<Button>("btnPlay");
        btnPlay.RegisterCallback<PointerDownEvent>(Down);
        btnPlay.RegisterCallback<PointerUpEvent>(Up);
        tvTitle = root.Q<Label>("tvTitle");
    }

    private void Down(PointerDownEvent evt)
    {
        Debug.Log("DOWN");
    }

    private void Up(PointerUpEvent evt)
    {
        Debug.Log("UP");
        tvTitle.text = "Xin Chao";
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
