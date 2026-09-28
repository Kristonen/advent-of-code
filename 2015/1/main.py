
input : str

def which_floor(input : str) -> int:
    current_floor : int = 0
    for c in input:
        if c == '(':
            current_floor += 1
        elif c == ')':
            current_floor -= 1

def check_for_first_basement_entry(input : str) -> int:
    pos : int = 1
    current_floor : int = 0
    for c in input:
        if c == '(':
            current_floor += 1
        elif c == ')':
            current_floor -= 1

        if current_floor < 0:
            return pos
        pos += 1
    

def start_task() -> None:
    with open("puzzle.txt") as f:
        input = f.read()

    current_floor : int = which_floor(input)
    pos : int = check_for_first_basement_entry(input)

    print(current_floor)
    print(pos)

if __name__ == "__main__":
    start_task()