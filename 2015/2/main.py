class Box:
    w : int
    l : int
    h : int

    def __init__(self, w : int, l : int, h : int):
        self.w = w
        self.l = l
        self.h = h

    @property
    def get_shortest_side(self) -> int:
        return min(self.w*self.l, self.w*self.h, self.l*self.h)

    @property
    def get_total_size(self) -> int:
        return 2*self.w*self.l + 2*self.w*self.h + 2*self.l*self.h + self.get_shortest_side

    @property
    def get_ribbon_min(self) -> int:
        total_w : int = self.w*2
        total_h : int = self.h*2
        total_l : int = self.l*2
        shortest_side : int = min(total_w+total_h, total_w+total_l, total_h+total_l)
        shortest_side += self.w*self.l*self.h
        return shortest_side

def start_task() -> None:
    amount : int = 0
    ribbon_amount : int = 0
    input : str
    with open("2015/2/puzzle.txt") as f:
        input = f.read()
    lines = input.split('\n')
    for line in lines:
        boxes_number = line.split('x')
        box = Box(int(boxes_number[0]), int(boxes_number[1]), int(boxes_number[2]))
        amount += box.get_total_size
        ribbon_amount += box.get_ribbon_min
    print(amount)
    print(ribbon_amount)

if __name__ == "__main__":
    start_task()