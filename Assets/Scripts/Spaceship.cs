using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Bounds _cameraBounds;
    private SpriteRenderer _spriteRenderer;

   
    public float speed = 10;

    private IMovementController _movementController;
    private IGunController _gunController;

    public void SetMovementController(IMovementController movementController)
    {
        _movementController = movementController;
    }

    public void SetGunController(IGunController gunController)
    {
        _gunController = gunController;
    }

    public void MoveHorizontaly (float x)
    {
        _movementController.MoveHorizontaly(x * GetSpeed());
    }

    public void MoveVerticaly(float y)
    {
        _movementController.MoveVerticaly(y * GetSpeed());
    }
    public float GetSpeed()
    {
        return speed;
    }
    
    public void ApplyFire()
    {
        _gunController.Fire();
    }

    private void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Camera.main.aspect;

        var size = new Vector3(width, height);
        _cameraBounds = new Bounds(Vector3.zero, size);

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void LateUpdate()
    {
        var newPosition = transform.position;

        //var spriteWidth = _spriteRenderer.sprite.rect.width / 2;
        //var spriteHeight = _spriteRenderer.sprite.rect.height / 2;



        newPosition.x = Mathf.Clamp(transform.position.x, _cameraBounds.min.x + 0.5f, _cameraBounds.max.x - 0.5f);
        newPosition.y = Mathf.Clamp(transform.position.y, _cameraBounds.min.y + 0.5f, _cameraBounds.max.y - 0.5f);

        transform.position = newPosition;
    }
}
