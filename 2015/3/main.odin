package main

import "core:fmt"
import "core:os"

Vec :: struct{
	x : int,
	y : int
}

check_vec_is_in_arr :: proc(arr : [dynamic]Vec, vec : Vec) -> bool{
	for other_vec in arr{
		if other_vec.x == vec.x && other_vec.y == vec.y do return true
	}
	return false
}

main :: proc(){
	data, err := os.read_entire_file("2015/3/puzzle.txt", context.allocator)

	if err != nil{
		fmt.println(err)
		return
	}

	defer delete(data, context.allocator)
	start_pos : Vec = Vec{0, 0}
	robo_pos : Vec = Vec{0, 0}
	command : int = 2
	arr_vecs : [dynamic]Vec
	append(&arr_vecs, start_pos)
	defer delete(arr_vecs)
	input := string(data)

	for r in input{
		pos : ^Vec
		if command % 2 == 0 do pos = &start_pos
		else do pos = &robo_pos
		calc_pos(r, pos)
		if !check_vec_is_in_arr(arr_vecs, pos^){
			append(&arr_vecs, pos^)
		}
		command += 1
	}
	fmt.printfln("Es wurden insgesamt %i Häuser besucht!", len(arr_vecs))
	fmt.println("Lief durch")
}

calc_pos :: proc(r : rune, pos : ^Vec){
	switch(r){
		case '>':
			fmt.println("Rechts")
			pos.x += 1
			break
		case '<':
			fmt.println("Links")
			pos.x -= 1
			break
		case 'v':
			fmt.println("Unten")
			pos.y += 1
			break
		case '^':
			fmt.println("Oben")
			pos.y -= 1
			break
		case:
			fmt.println("NIX")
			break
	}
}
