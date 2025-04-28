using UnityEngine;
using UnityEngine.EventSystems;

public class Dragging : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    public AudioClip dragSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (dragSound != null)
        {
            audioSource.PlayOneShot(dragSound); // ドラッグ開始時に効果音を鳴らす
        }
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
        }
    }
}
