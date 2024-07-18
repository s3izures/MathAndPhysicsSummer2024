#include <iostream>
#include <vector>
#include <string>

void velocityAcceleration();
void motionEquations();
float moEq1(int targetVariable, float variables[6]);
float moEq2(int targetVariable, float variables[6]);
float moEq3(int targetVariable, float variables[6]);
float moEq4(int targetVariable, float variables[6]);
float moEq5(int targetVariable, float variables[6]);
void vectorAcceleration();

int main()
{
    velocityAcceleration();
    motionEquations();
    //vectorAcceleration();
}

void velocityAcceleration()
{
    // TASK: Write a simple program that will ask for a polynomial that presents the object�s position in timeand returns instantaneous velocity and acceleration in a specified moment.
    int highestOrder = 0;
    std::vector<float> coefficients;
    float input = 0;
    float x = 0;
    float velocity = 0;
    float acceleration = 0;

    // Ask user for highest order
    std::cout << "Enter highest order: ";
    std::cin >> highestOrder;

    //Ask user for coefficients
    for (int i = highestOrder; i >= 0; i--)
    {
        if (i > 1) //higher than x (ex: x^2, x^6)
        {
            std::cout << "Enter coefficient of variable x^" << i << ": ";
        }
        else if (i == 1) //is x
        {
            std::cout << "Enter coefficient of variable x: ";
        }
        else //just a number
        {
            std::cout << "Enter constant variable: ";
        }
        std::cin >> input;
        coefficients.push_back(input);
    }


    //Ask for moment
    std::cout << std::endl << "Enter value of x: ";
    std::cin >> x;


    //Show equation
    std::cout << std::endl << "Equation: ";
    for (int i = highestOrder; i >= 0; i--)
    {
        if (coefficients[highestOrder - i] != 0)
        {
            //print sign if positive
            if (i < highestOrder)
            {
                if (coefficients[highestOrder - i] >= 0)
                {
                    std::cout << "+";
                }
            }

            //print coefficients
            if (i > 1) //higher than x (ex: x^2, x^6)
            {
                std::cout << coefficients[highestOrder - i] << "x^" << i;
            }
            else if (i == 1) //is x
            {
                std::cout << coefficients[highestOrder - i] << "x";
            }
            else //just a number
            {
                std::cout << coefficients[highestOrder - i];
            }
        }
    }


    //Show differentiated equation
    std::cout << std::endl << "Differentiated Equation: ";
    for (int i = highestOrder; i >= 0; i--)
    {
        if (coefficients[highestOrder - i] != 0)
        {
            //print sign if positive, constant is dropped
            if (i < highestOrder && i > 0)
            {
                if (coefficients[highestOrder - i] >= 0)
                {
                    std::cout << "+";
                }
            }

            //print coefficients
            if (i > 2) //higher than x^2 (ex: x^2, x^6)
            {
                //y' = n*x^(n-1)
                std::cout << i * coefficients[highestOrder - i] << "x^" << i - 1;
            }
            else if (i == 2) //is x
            {
                std::cout << i * coefficients[highestOrder - i] << "x";
            }
            else if (i == 1) //constant is dropped
            {
                std::cout << coefficients[highestOrder - i];
            }
        }
    }


    //Calculate velocity
    for (int i = highestOrder; i >= 0; i--)
    {
        if (i > 0)
        {
            velocity += coefficients[highestOrder - i] * powf(x, i);
        }
        else
        {
            velocity += coefficients[highestOrder - i];
        }
    }


    //Calculate acceleration (differentiation of velocity)
    for (int i = highestOrder; i >= 0; i--)
    {
        if (i > 1)
        {
            //y' = n*x^(n-1)
            acceleration += (i * coefficients[highestOrder - i]) * powf(x, i - 1);
        }
        else if (x == 1) // constant is dropped
        {
            acceleration += (i * coefficients[highestOrder - i]);
        }
    }

    std::cout << std::endl;

    //Display velocity and acceleration
    std::cout << "Velocity: " << velocity << std::endl;
    std::cout << "Acceleration: " << acceleration << std::endl;
}

void motionEquations()
{
    //TASK: Create a library of functions using all five equations of motion. Each equation should be used more than once to solve each variable involved.

    std::string variableName[6] = { "Final Velocity","Initial Velocity", "Average Velocity", "Acceleration", "Time", "Displacement" };
    bool isVariable[6] = { false, false, false, false, false, false };
    float variableValues[6] = { 0, 0, 0, 0, 0 ,0 };

    int input = -1;
    int variableToFind;
    float result = 0;
    int equation = -1;


    //Ask user what they're looking for
    std::cout << "Which variable(s) are you looking for?" << std::endl;
    for (int i = 0; i < 6; i++)
    {
        std::cout << i << ". " << variableName[i] << std::endl;
    }

    while (input < 0 || input >= 6)
    {
        std::cout << "Enter the number beside the chosen variable: ";
        std::cin >> input;

        if (input < 0 || input >= 6)
        {
            std::cout << "Invalid input" << std::endl;
        }
    }

    variableToFind = input;

    system("CLS");

    std::cout << "Looking for " << variableName[variableToFind] << std::endl;


    //Ask user what values they have
    input = 0;

    std::cout << "What variables do you have?: " << std::endl << std::endl;

    for (int i = 0; i < 6; i++)
    {
        if (variableToFind != i)
        {
            std::cout << i << ". " << variableName[i] << std::endl;
        }
    }

    do {
        std::cout << "Enter the number beside the chosen variable, enter -1 to end: ";
        std::cin >> input;
        if (input >= 0 && input < 6 && input != variableToFind)
        {
            isVariable[input] = true;
        }
        else if (input != -1)
        {
            std::cout << "Not an option." << std::endl;
        }
    } while (input != -1);
    std::cout << std::endl;

    std::cout << "Enter value of ";
    for (int i = 0; i < 6; i++)
    {
        if (isVariable[i])
        {
            std::cout << variableName[i] << ": ";
            std::cin >> variableValues[i];
        }
    }

    system("CLS");

    std::cout << "Available Values" << std::endl;
    for (int i = 0; i < 6; i++)
    {
        if (isVariable[i])
        {
            std::cout << variableName[i] << " = " << variableValues[i] << std::endl;
        }
    }
    std::cout << std::endl;


    //Calculate based on what values are present
    if (variableToFind == 0) //Final Velocity
    {
        if (isVariable[1] && isVariable[3] && isVariable[4])
        {
            equation = 1;
        }
        else if (isVariable[1] && isVariable[2])
        {
            equation = 2;
        }
        else if (isVariable[1] && isVariable[5] && isVariable[4])
        {
            equation = 3;
        }
        else if (isVariable[1] && isVariable[3] && isVariable[5])
        {
            equation = 5;
        }
    }
    else if (variableToFind == 1) //Initial Velocity
    {
        if (isVariable[0] && isVariable[3] && isVariable[4])
        {
            equation = 1;
        }
        else if (isVariable[0] && isVariable[2])
        {
            equation = 2;
        }
        else if (isVariable[0] && isVariable[4] && isVariable[5])
        {
            equation = 3;
        }
        else if (isVariable[3] && isVariable[4] && isVariable[5])
        {
            equation = 4;
        }
        else if (isVariable[0] && isVariable[3] && isVariable[5])
        {
            equation = 5;
        }
    }
    else if (variableToFind == 2) //Average Velocity
    {
        if (isVariable[0] && isVariable[1])
        {
            equation = 2;
        }
    }
    else if (variableToFind == 3) //Acceleration
    {
        if (isVariable[0] && isVariable[1] && isVariable[4])
        {
            equation = 1;
        }
        else if (isVariable[2] && isVariable[4] && isVariable[5])
        {
            equation = 4;
        }
        else if (isVariable[0] && isVariable[2] && isVariable[5])
        {
            equation = 5;
        }
    }
    else if (variableToFind == 4) //Time
    {
        if (isVariable[0] && isVariable[1] && isVariable[3])
        {
            equation = 1;
        }
        else if (isVariable[0] && isVariable[1] && isVariable[5])
        {
            equation = 3;
        }
        else if (isVariable[1] && isVariable[3] && isVariable[5])
        {
            equation = 4;
        }
    }
    else if (variableToFind == 5) //Displacement
    {
        //3,4,5
        if (isVariable[0] && isVariable[1] && isVariable[4])
        {
            equation = 3;
        }
        else if (isVariable[1] && isVariable[3] && isVariable[4])
        {
            equation = 4;
        }
        else if (isVariable[0] && isVariable[1] && isVariable[4])
        {
            equation = 5;
        }
    }

    switch (equation)
    {
    case 1:
        result = moEq1(variableToFind, variableValues);
        break;
    case 2:
        result = moEq2(variableToFind, variableValues);
        break;
    case 3:
        result = moEq3(variableToFind, variableValues);
        break;
    case 4:
        result = moEq4(variableToFind, variableValues);
        break;
    case 5:
        result = moEq5(variableToFind, variableValues);
        break;
    }

    if (equation == -1)
    {
        std::cout << "Unable to calculate results." << std::endl;
    }
    else
    {
        std::cout << variableName[variableToFind] << ": " << result << std::endl;
    }

}
float moEq1(int targetVariable, float variables[6])
{
    float vF = variables[0];
    float vI = variables[1];
    float a = variables[3];
    float t = variables[4];

    if (targetVariable == 0)
    {
        std::cout << "final velocity = initial velocity + acceleration * time" << std::endl;
        vF = vI + a * t;
        return vF;
    }
    else if (targetVariable == 1)
    {
        std::cout << "initial velocity = final velocity / time - acceleration" << std::endl;
        vI = vF - a * t;
        return vI;
    }
    else if (targetVariable == 3)
    {
        std::cout << "acceleration = final velocity / time - initial velocity" << std::endl;
        if (t != 0)
        {
            a = (vF - vI) / t;
            return a;
        }
        else
        {
            std::cout << "ERROR, time cannot be 0" << std::endl;
        }
    }
    else if (targetVariable == 4)
    {
        std::cout << "time = final velocity / acceleration - initial velocity" << std::endl;
        if (a != 0)
        {
            t = (vF - vI) / a;
            return t;
        }
        else
        {
            std::cout << "ERROR, acceleration cannot be 0" << std::endl;
        }
    }
    return NULL;
}
float moEq2(int targetVariable, float variables[6])
{
    float vF = variables[0];
    float vI = variables[1];
    float vA = variables[2];

    if (targetVariable == 0)
    {
        std::cout << "final velocity = average velocity * 2 - initial velocity" << std::endl;
        vF = vA * 2 - vI;
        return vF;
    }
    else if (targetVariable == 1)
    {
        std::cout << "initial velocity = average velocity * 2 - final velocity" << std::endl;
        vI = vA * 2 - vF;
        return vI;
    }
    else if (targetVariable == 2)
    {
        std::cout << "average velocity = (initial velocity + final velocity) / 2" << std::endl;
        vA = (vI + vF) / 2;
        return vA;
    }
    return NULL;
}
float moEq3(int targetVariable, float variables[6])
{
    float vF = variables[0];
    float vI = variables[1];
    float t = variables[4];
    float x = variables[5];

    if (targetVariable == 0)
    {
        std::cout << "final velocity = ( 2 * displacement ) / time - initial velocity" << std::endl;
        if (t != 0)
        {
            vF = (2 * x) / t - vI;
            return vF;
        }
        else
        {
            std::cout << "ERROR, time cannot be 0" << std::endl;
        }
    }
    else if (targetVariable == 1)
    {
        std::cout << "initial velocity = ( 2 * displacement ) / time - final velocity" << std::endl;
        if (t != 0)
        {
            vI = (2 * x) / t - vF;
            return vI;
        }
        else
        {
            std::cout << "ERROR, time cannot be 0" << std::endl;
        }
    }
    else if (targetVariable == 4)
    {
        std::cout << "time = ( 2 * displacement ) / ( final velocity + initial velocity )" << std::endl;
        if (vF + vI != 0)
        {
            t = (2 * x) / (vF + vI);
            return t;
        }
        else
        {
            std::cout << "ERROR, sum of final and initial velocity cannot be 0" << std::endl;
        }
    }
    else if (targetVariable == 5)
    {
        std::cout << "displacement = 1/2 (initial velocity + final velocity) * time" << std::endl;
        x = (1 / 2) * (vI + vF) * t;
        return x;
    }
    return NULL;

}
float moEq4(int targetVariable, float variables[6])
{
    float vI = variables[1];
    float a = variables[3];
    float t = variables[4];
    float x = variables[5];

    if (targetVariable == 1)
    {
        std::cout << "initial velocity = ( displacement / time ) - ( (acceleration * time) / 2)" << std::endl;
        if (t != 0)
        {
            vI = (x / t) - ((a * t) / 2);
            return vI;
        }
        else
        {
            std::cout << "ERROR, time cannot be 0" << std::endl;
        }
    }
    else if (targetVariable == 3)
    {
        std::cout << "acceleration = (2 * (displacement - initial velocity * time)) / time^2" << std::endl;
        if (t != 0)
        {
            a = (2 * (x - vI * t)) / powf(t, 2);
            return a;
        }
        else
        {
            std::cout << "ERROR, time cannot be 0" << std::endl;
        }
    }
    else if (targetVariable == 4)
    {
        if (a == 0)
        {
            t = -vI * x;
            return t;
        }
        else
        {
            float t1 = (sqrtf(2 * a * x + powf(vI, 2)) + vI) / a;
            float t2 = (sqrtf(2 * a * x + powf(vI, 2)) - vI) / a;
            if (t1 >= 0)
            {
                return t1;
            }
            else if (t2 >= 0)
            {
                return t2;
            }
            else
            {
                std::cout << "Cannot find an answer..." << std::endl;
            }
        }
    }
    else if (targetVariable == 5)
    {
        x = (vI * t) + ((1 / 2) * a * powf(t, 2));
        return x;
    }
    return NULL;
}
float moEq5(int targetVariable, float variables[6])
{
    float vF = variables[0];
    float vI = variables[1];
    float a = variables[3];
    float x = variables[5];

    //final velocity^2 = initial velocity^2 + 2 * acceleration * displacement
    if (targetVariable == 0)
    {
        std::cout << "final velocity = sqrt( 2 * acceleration * displacement + initial velocity^2 )" << std::endl;
        vF = fabs(sqrtf(2 * a * x + powf(vI, 2)));
        std::cout << "Note that the answer is +- due to the square root." << std::endl;
        return vF;
    }
    else if (targetVariable == 1)
    {
        std::cout << "initial velocity = sqrt( final velocity^2 - 2 * acceleration * displacement )" << std::endl;
        vI = fabs(sqrtf(powf(vF, 2) - 2 * a * x));
        std::cout << "Note that the answer is +- due to the square root." << std::endl;
        return vI;
    }
    else if (targetVariable == 3)
    {
        std::cout << "acceleration = ( final velocity^2 - initial velocity^2 ) / 2 * displacement" << std::endl;
        if (x != 0)
        {
            a = (powf(vF, 2) - powf(vI, 2)) / 2 * x;
            return a;
        }
        else
        {
            std::cout << "ERROR, displacement cannot be 0" << std::endl;
        }
    }
    else if (targetVariable == 5)
    {
        std::cout << "displacement = ( final velocity^2 - initial velocity^2 ) / 2 * acceleration" << std::endl;
        if (a != 0)
        {
            x = (powf(vF, 2) - powf(vI, 2)) / 2 * a;
            return x;
        }
        else
        {
            std::cout << "ERROR, acceleration cannot be 0" << std::endl;
        }
    }
    return NULL;
}

void vectorAcceleration()
{
    //TASK: Write a simple program that will ask for an object�s weight and all the forces acting on the object and return the resulting acceleration. (acceleration should be a scalar)
}