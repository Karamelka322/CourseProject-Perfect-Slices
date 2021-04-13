using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    [SerializeField] private Image _foodBar;
    [SerializeField] private Conveyor _conveyor;
    [SerializeField] private float _maxValueFoodbar;

    private float _partValueFoodBar;
    private float _counter;

    private void Start()
    {
        _partValueFoodBar = 1 / _maxValueFoodbar;
    }

    private void OnEnable()
    {
        _conveyor.DestroyFood += OnDestroyFood;
    }

    private void OnDisable()
    {
        _conveyor.DestroyFood -= OnDestroyFood;        
    }

    private void OnDestroyFood()
    {
        _counter++;

        if(_counter <= _maxValueFoodbar)
        {
            _foodBar.fillAmount += _partValueFoodBar;
        }
    }
}
